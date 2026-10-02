using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_Entity;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly ICustomerService _customerService;

        public TestimonialController(ITestimonialService testimonialService, ICustomerService customerService)
        {
            _testimonialService = testimonialService;
            _customerService = customerService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var values = _testimonialService.GetAll()
                .OrderByDescending(item => item.CreatedDate)
                .Select(item =>
                {
                    var customer = _customerService.GetById(item.CustomerId);
                    return new TestimonialAdminItemViewModel
                    {
                        Testimonial = item,
                        CustomerName = customer?.NameSurname ?? item.ClientName,
                        CustomerEmail = customer?.Email,
                        ProfileImageUrl = customer?.ProfileImageUrl ?? item.ImageUrl
                    };
                })
                .ToList();
            return View(values);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTestimonialViewModel());
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTestimonialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerId = int.TryParse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var id) ? id : 0;
            var customer = customerId > 0 ? _customerService.GetById(customerId) : null;
            if (customer == null || !customer.IsActive)
            {
                return Challenge();
            }

            _testimonialService.Create(new Testimonial
            {
                ClientName = customer.NameSurname,
                Title = "Yalçın Hotel misafiri",
                Comment = model.Comment.Trim(),
                ImageUrl = customer.ProfileImageUrl ?? $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(customer.NameSurname)}&background=0f2027&color=d4af37&size=160",
                Rating = model.Rating,
                CustomerId = customer.Id,
                CreatedDate = DateTime.Now,
                IsActive = false
            });

            TempData["TestimonialMessage"] = "Yorumunuz alındı. Yönetici onayından sonra otel sitesinde yayımlanacaktır.";
            return RedirectToAction("Profile", "Account");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleVisibility(int id)
        {
            var testimonial = _testimonialService.GetById(id);
            if (testimonial == null)
            {
                return NotFound();
            }

            testimonial.IsActive = !testimonial.IsActive;
            _testimonialService.Update(testimonial);
            TempData["TestimonialMessage"] = testimonial.IsActive
                ? "Yorum otel sitesinde yayımlandı."
                : "Yorum otel sitesinden kaldırıldı.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var testimonial = _testimonialService.GetById(id);
            if (testimonial == null)
            {
                return NotFound();
            }

            _testimonialService.Delete(testimonial);
            TempData["TestimonialMessage"] = "Müşteri yorumu silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
