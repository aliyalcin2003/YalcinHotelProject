using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.RoomDTO;
namespace YalcinHotel_UI.ViewComponents.Home
{
 [ViewComponent(Name = "_HomePopularRoomViewComponentPartial")]
 public class _HomePopularRoomViewComponentPartial : ViewComponent
 {
  private readonly IRoomService _service; private readonly IMapper _mapper;
  public _HomePopularRoomViewComponentPartial(IRoomService service, IMapper mapper) { _service=service; _mapper=mapper; }
  public IViewComponentResult Invoke()
  {
   var model=_mapper.Map<List<ResultRoomDTO>>(_service.GetPopularAll());
   return View("~/Views/Shared/_HomePopularRoomViewComponentPartial/Default.cshtml", model);
  }
 }
}