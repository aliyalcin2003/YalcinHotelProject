using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.DTOs.ContactDTO;
namespace YalcinHotel_UI.ViewComponents.Contact
{
    // İletişim formunun boş modelini oluşturup formun Razor görünümüne iletir.
    public class _ContactDetailViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new CreateContactDTO();

            return View("~/Views/Shared/_ContactDetailViewComponentPartial/Default.cshtml", model);
        }
    }
}
