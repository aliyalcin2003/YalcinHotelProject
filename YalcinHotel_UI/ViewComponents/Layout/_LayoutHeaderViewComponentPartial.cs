using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
    // Site layout'unda kullanılabilecek ortak header görünümünü temsil eder.
    public class _LayoutHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_LayoutHeaderViewComponentPartial/Default.cshtml");
        }
    }
}
