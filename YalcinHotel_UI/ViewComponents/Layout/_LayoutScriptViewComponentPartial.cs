using Microsoft.AspNetCore.Mvc;
namespace YalcinHotel_UI.ViewComponents.Layout
{
 [ViewComponent(Name = "_LayoutScriptViewComponentPartial")]
 public class _LayoutScriptViewComponentPartial : ViewComponent
 {
  public IViewComponentResult Invoke() => View("~/Views/Shared/_LayoutScriptViewComponentPartial/Default.cshtml");
 }
}