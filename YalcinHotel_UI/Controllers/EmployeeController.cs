using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_Entity;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAboutService _aboutService;

        public EmployeeController(IEmployeeService employeeService, IAboutService aboutService)
        {
            _employeeService = employeeService;
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.GetAll()
                .OrderByDescending(item => item.IsActive && item.Status)
                .ThenBy(item => item.Name)
                .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateAbouts();
            return View(new EmployeeCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (!IsHttpUrl(model.ImageUrl))
                ModelState.AddModelError(nameof(model.ImageUrl), "Fotoğraf http veya https adresi olmalıdır.");

            var about = _aboutService.GetById(model.AboutId);
            if (about == null || !about.IsActive)
                ModelState.AddModelError(nameof(model.AboutId), "Çalışanın bağlanacağı aktif Hakkımızda kaydını seçin.");

            if (!ModelState.IsValid)
            {
                PopulateAbouts(model.AboutId);
                return View(model);
            }

            _employeeService.Create(new Employee
            {
                Name = model.Name.Trim(),
                Surname = model.Surname.Trim(),
                Title = model.Title.Trim(),
                ImageUrl = model.ImageUrl.Trim(),
                AboutId = model.AboutId,
                Status = true,
                IsActive = true
            });

            TempData["EmployeeMessage"] = "Çalışan otel ekibine eklendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();

            employee.Status = !employee.Status;
            employee.IsActive = employee.Status;
            _employeeService.Update(employee);
            TempData["EmployeeMessage"] = employee.Status
                ? "Çalışan yeniden aktif edildi."
                : "Çalışan ekip listesinden çıkarıldı.";
            return RedirectToAction(nameof(Index));
        }

        private void PopulateAbouts(int? selectedId = null)
        {
            ViewBag.Abouts = _aboutService.GetAll(item => item.IsActive)
                .Select(item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Title,
                    Selected = selectedId == item.Id
                })
                .ToList();
        }

        private static bool IsHttpUrl(string? value) =>
            Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}
