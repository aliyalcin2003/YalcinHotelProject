using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IRepositoryService<About> _aboutService;

        public AboutController(IRepositoryService<About> aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.GetAll();
            return View(values);
        }
    }
}
