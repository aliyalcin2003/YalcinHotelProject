using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.SliderDTO;
namespace YalcinHotel_UI.ViewComponents.Home
{
 [ViewComponent(Name = "_HomeSliderViewComponentPartial")]
 public class _HomeSliderViewComponentPartial : ViewComponent
 {
  private readonly ISliderService _service; private readonly IMapper _mapper;
  public _HomeSliderViewComponentPartial(ISliderService service, IMapper mapper) { _service=service; _mapper=mapper; }
  public IViewComponentResult Invoke()
  {
   var item=_service.GetOne(x=>x.Page=="Home" && x.IsActive);
   var model=item==null?null:_mapper.Map<ResultSliderDTO>(item);
   return View("~/Views/Shared/_HomeSliderViewComponentPartial/Default.cshtml", model);
  }
 }
}
