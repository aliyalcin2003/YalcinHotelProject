using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_Entity;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetAll()
                .OrderByDescending(item => item.IsActive) //OrderByDescending: Bu yöntem, bir koleksiyonu belirli bir özelliğe göre azalan sırada sıralar. Bu durumda, hizmetler önce etkinlik durumuna göre sıralanır; yani etkin olan hizmetler önce gelir.
                .ThenBy(item => item.Title) //ThenBy: Bu yöntem, bir koleksiyonu birincil sıralama kriterine ek olarak ikincil bir kritere göre sıralar. Bu durumda, hizmetler önce etkinlik durumuna göre sıralandıktan sonra başlıklarına göre alfabetik olarak sıralanır.
                .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ServiceManagementViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceManagementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _serviceService.Create(new Service
            {
                Title = model.Title.Trim(),
                Description = model.Description.Trim(),
                IconUrl = model.IconUrl.Trim(),
                IsActive = true
            });
            TempData["ServiceMessage"] = "Hizmet eklendi ve sitede yayımlandı.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _serviceService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }

            return View(new ServiceManagementViewModel
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceManagementViewModel model)
        {
            var value = _serviceService.GetById(model.Id);
            if (value == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            value.Title = model.Title.Trim(); //Trim(): Bu yöntem, bir string'in başındaki ve sonundaki boşlukları kaldırır. Bu, kullanıcıdan alınan verilerin temizlenmesini sağlar ve gereksiz boşlukların veri tabanına kaydedilmesini önler.
            value.Description = model.Description.Trim();
            value.IconUrl = model.IconUrl.Trim();
            _serviceService.Update(value);
            TempData["ServiceMessage"] = "Hizmet bilgileri güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            var value = _serviceService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }

            value.IsActive = !value.IsActive;
            _serviceService.Update(value);
            TempData["ServiceMessage"] = value.IsActive
                ? "Hizmet sitede etkinleştirildi."
                : "Hizmet siteden kaldırıldı.";
            return RedirectToAction(nameof(Index)); //RedirectToAction: Belirtilen eylem yöntemine yönlendirme yapar. Bu, kullanıcıyı başka bir sayfaya veya eyleme yönlendirmek için kullanılır.
        }
    }
}
