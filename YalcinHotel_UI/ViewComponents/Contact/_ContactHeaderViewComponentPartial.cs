using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Contact
{
    // İletişim sayfasında ortak üst başlık görünümünü çağırır.
    public class _ContactHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_ContactHeaderViewComponentPartial/Default.cshtml");
        }
    }
}
