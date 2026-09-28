using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    [ViewComponent(Name = "_AdminNavbarViewComponentPartial")]
    public class _AdminNavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View("~/Views/Shared/_AdminNavbarViewComponentPartial/Default.cshtml");
    }
}
