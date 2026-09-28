using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
 [ViewComponent(Name = "_LayoutHeaderViewComponentPartial")]
 public class _LayoutHeaderViewComponentPartial : ViewComponent
 {
  public IViewComponentResult Invoke() => View("~/Views/Shared/_LayoutHeaderViewComponentPartial/Default.cshtml");
 }
}