using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
 [ViewComponent(Name = "_LayoutNavbarViewComponentPartial")]
 public class _LayoutNavbarViewComponentPartial : ViewComponent
 {
  public IViewComponentResult Invoke() => View("~/Views/Shared/_LayoutNavbarViewComponentPartial/Default.cshtml");
 }
}