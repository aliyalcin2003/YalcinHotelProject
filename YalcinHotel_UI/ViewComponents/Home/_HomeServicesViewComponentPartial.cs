using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;

namespace YalcinHotel_UI.ViewComponents.Home
{
    [ViewComponent(Name = "_HomeServicesViewComponentPartial")]
    public class _HomeServicesViewComponentPartial : ViewComponent
    {
        private readonly IServiceService _service;

        public _HomeServicesViewComponentPartial(IServiceService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var services = _service.GetAll();
            return View("~/Views/Shared/_HomeServicesViewComponentPartial/Default.cshtml", services);
        }
    }
}
