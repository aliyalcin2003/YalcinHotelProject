using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    // Admin üst çubuğunu ayrı bir görünüm olarak layout'a bağlar.
    public class _AdminNavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_AdminNavbarViewComponentPartial/Default.cshtml");
        }
    }
}
