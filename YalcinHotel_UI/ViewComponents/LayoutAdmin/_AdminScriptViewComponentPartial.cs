using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    // Admin sayfalarında gerekli doğrulama ve panel scriptlerini ortak noktadan yükler.
    public class _AdminScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_AdminScriptViewComponentPartial/Default.cshtml");
        }
    }
}
