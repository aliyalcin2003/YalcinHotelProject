using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    // Admin sayfalarının başlık alanındaki ortak kaynakları ve stilleri yükler.
    public class _AdminHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_AdminHeaderViewComponentPartial/Default.cshtml");
        }
    }
}
