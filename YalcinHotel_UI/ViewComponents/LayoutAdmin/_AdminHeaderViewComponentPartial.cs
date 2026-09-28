using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    [ViewComponent(Name = "_AdminHeaderViewComponentPartial")]
    public class _AdminHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View("~/Views/Shared/_AdminHeaderViewComponentPartial/Default.cshtml");
    }
}
