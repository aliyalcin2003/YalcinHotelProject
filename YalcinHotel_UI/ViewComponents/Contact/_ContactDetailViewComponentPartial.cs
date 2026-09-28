using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.DTOs.ContactDTO;
namespace YalcinHotel_UI.ViewComponents.Contact
{
 [ViewComponent(Name = "_ContactDetailViewComponentPartial")]
 public class _ContactDetailViewComponentPartial : ViewComponent
 {
  public IViewComponentResult Invoke() => View("~/Views/Shared/_ContactDetailViewComponentPartial/Default.cshtml", new CreateContactDTO());
 }
}