using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
 [ViewComponent(Name = "_LayoutFooterViewComponentPartial")]
 public class _LayoutFooterViewComponentPartial : ViewComponent
 {
  public IViewComponentResult Invoke() => View("~/Views/Shared/_LayoutFooterViewComponentPartial/Default.cshtml");
 }
}