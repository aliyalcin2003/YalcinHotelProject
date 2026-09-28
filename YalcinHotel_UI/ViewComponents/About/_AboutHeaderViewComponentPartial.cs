using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.SliderDTO;
namespace YalcinHotel_UI.ViewComponents.About
{
 [ViewComponent(Name = "_AboutHeaderViewComponentPartial")]
 public class _AboutHeaderViewComponentPartial : ViewComponent
 {
  private readonly ISliderService _service; private readonly IMapper _mapper;
  public _AboutHeaderViewComponentPartial(ISliderService service, IMapper mapper) { _service=service; _mapper=mapper; }
  public IViewComponentResult Invoke()
  {
   var item=_service.GetOne(x=>x.Page=="About" && x.IsActive);
   var model=item==null?null:_mapper.Map<ResultSliderDTO>(item);
   return View("~/Views/Shared/_AboutHeaderViewComponentPartial/Default.cshtml", model);
  }
 }
}
