using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    [ViewComponent(Name = "_AdminScriptViewComponentPartial")]
    public class _AdminScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View("~/Views/Shared/_AdminScriptViewComponentPartial/Default.cshtml");
    }
}
