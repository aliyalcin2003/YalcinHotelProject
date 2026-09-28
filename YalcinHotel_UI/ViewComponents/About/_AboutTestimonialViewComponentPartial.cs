using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
namespace YalcinHotel_UI.ViewComponents.About
{
 [ViewComponent(Name = "_AboutTestimonialViewComponentPartial")]
 public class _AboutTestimonialViewComponentPartial : ViewComponent
 {
  private readonly ITestimonialService _service;
  public _AboutTestimonialViewComponentPartial(ITestimonialService service) { _service=service; }
 public IViewComponentResult Invoke() => View("~/Views/Shared/_AboutTestimonialViewComponentPartial/Default.cshtml", _service.GetAll(item => item.IsActive));
 }
}
