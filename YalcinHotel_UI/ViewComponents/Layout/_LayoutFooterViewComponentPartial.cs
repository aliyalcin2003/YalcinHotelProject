using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
    public class _LayoutFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_LayoutFooterViewComponentPartial/Default.cshtml");
        }
    }
}
