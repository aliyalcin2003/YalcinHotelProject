using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    [ViewComponent(Name = "_AdminSidebarViewComponentPartial")]
    public class _AdminSidebarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View("~/Views/Shared/_AdminSidebarViewComponentPartial/Default.cshtml");
    }
}
