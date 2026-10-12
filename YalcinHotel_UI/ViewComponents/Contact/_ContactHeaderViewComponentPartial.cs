using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Contact
{
    public class _ContactHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_ContactHeaderViewComponentPartial/Default.cshtml");
        }
    }
}
