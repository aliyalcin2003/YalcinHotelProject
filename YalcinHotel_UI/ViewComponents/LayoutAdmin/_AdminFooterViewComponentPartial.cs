using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    [ViewComponent(Name = "_AdminFooterViewComponentPartial")]
    public class _AdminFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View("~/Views/Shared/_AdminFooterViewComponentPartial/Default.cshtml");
    }
}
