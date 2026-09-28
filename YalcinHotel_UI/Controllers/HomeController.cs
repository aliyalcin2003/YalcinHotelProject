using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;

namespace YalcinHotel_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceService _serviceService;

        public HomeController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Rooms() // Rooms sayfası için yeni bir action metodu ekledik çünkü Rooms sayfasına yönlendirme yapmamız gerekiyor.
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
    }
}
