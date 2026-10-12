using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
    // Site layout'u için ortak JavaScript dosyalarının bulunduğu görünümü çağırır.
    public class _LayoutScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_LayoutScriptViewComponentPartial/Default.cshtml");
        }
    }
}
