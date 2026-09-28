using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;

namespace YalcinHotel_UI.ViewComponents.Home
{
    [ViewComponent(Name = "_HomeTeamViewComponentPartial")]
    public class _HomeTeamViewComponentPartial : ViewComponent
    {
        private readonly IEmployeeService _employeeService;

        public _HomeTeamViewComponentPartial(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IViewComponentResult Invoke()
        {
            var employees = _employeeService.GetAll(item => item.IsActive && item.Status);
            return View("~/Views/Shared/_HomeTeamViewComponentPartial/Default.cshtml", employees);
        }
    }
}
