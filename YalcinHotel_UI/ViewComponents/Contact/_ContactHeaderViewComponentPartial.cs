using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Contact
{
 [ViewComponent(Name = "_ContactHeaderViewComponentPartial")]
 public class _ContactHeaderViewComponentPartial : ViewComponent
 {
  public IViewComponentResult Invoke() => View("~/Views/Shared/_ContactHeaderViewComponentPartial/Default.cshtml");
 }
}