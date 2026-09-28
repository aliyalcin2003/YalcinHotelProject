using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.AboutDTO;
namespace YalcinHotel_UI.ViewComponents.Home
{
 [ViewComponent(Name = "_HomeAboutViewComponentPartial")]
 public class _HomeAboutViewComponentPartial : ViewComponent
 {
  private readonly IAboutService _service; private readonly IMapper _mapper;
  public _HomeAboutViewComponentPartial(IAboutService service, IMapper mapper) { _service=service; _mapper=mapper; }
  public IViewComponentResult Invoke()
  {
   var model=_mapper.Map<List<ResultAboutDTO>>(_service.GetAll(item => item.IsActive));
   return View("~/Views/Shared/_HomeAboutViewComponentPartial/Default.cshtml", model);
  }
 }
}
