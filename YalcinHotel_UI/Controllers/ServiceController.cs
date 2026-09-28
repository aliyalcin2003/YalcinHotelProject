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
                .OrderByDescending(item => item.IsActive)
                .ThenBy(item => item.Title)
                .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create() => View(new ServiceManagementViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceManagementViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

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
                return NotFound();

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
                return NotFound();
            if (!ModelState.IsValid)
                return View(model);

            value.Title = model.Title.Trim();
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
                return NotFound();

            value.IsActive = !value.IsActive;
            _serviceService.Update(value);
            TempData["ServiceMessage"] = value.IsActive
                ? "Hizmet sitede etkinleştirildi."
                : "Hizmet siteden kaldırıldı.";
            return RedirectToAction(nameof(Index));
        }
    }
}
