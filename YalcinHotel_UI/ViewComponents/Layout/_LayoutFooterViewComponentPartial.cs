using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
    // Site sayfalarında tekrar kullanılan footer Razor görünümünü döndürür.
    public class _LayoutFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_LayoutFooterViewComponentPartial/Default.cshtml");
        }
    }
}
