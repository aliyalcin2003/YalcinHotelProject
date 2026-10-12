using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
    // Ortak site navigasyonunu ayrı bir bileşen olarak layout'a ekler.
    public class _LayoutNavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_LayoutNavbarViewComponentPartial/Default.cshtml");
        }
    }
}
