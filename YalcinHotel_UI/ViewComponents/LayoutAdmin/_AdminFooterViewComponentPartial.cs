using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    // Yönetim panelinin ortak alt bölümünü admin layout'una ekler.
    public class _AdminFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_AdminFooterViewComponentPartial/Default.cshtml");
        }
    }
}
