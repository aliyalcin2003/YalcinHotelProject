using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
namespace YalcinHotel_UI.ViewComponents.About
{
    // Hakkımızda bölümünde yalnızca yönetici tarafından yayımlanmış yorumları gösterir.
    public class _AboutTestimonialViewComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _AboutTestimonialViewComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _testimonialService.GetAll(item => item.IsActive);

            return View("~/Views/Shared/_AboutTestimonialViewComponentPartial/Default.cshtml", testimonials);
        }
    }
}
