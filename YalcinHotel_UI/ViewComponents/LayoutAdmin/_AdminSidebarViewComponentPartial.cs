using Microsoft.AspNetCore.Mvc;

namespace YalcinHotel_UI.ViewComponents.LayoutAdmin
{
    // Yönetim menüsünü admin layout'unda tekrar kullanılabilir hale getirir.
    public class _AdminSidebarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/_AdminSidebarViewComponentPartial/Default.cshtml");
        }
    }
}
