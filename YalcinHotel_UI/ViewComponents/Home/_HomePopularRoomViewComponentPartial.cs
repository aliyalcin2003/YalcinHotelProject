using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.RoomDTO;
namespace YalcinHotel_UI.ViewComponents.Home
{
    public class _HomePopularRoomViewComponentPartial : ViewComponent
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public _HomePopularRoomViewComponentPartial(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var popularRooms = _roomService.GetPopularAll();
            var model = _mapper.Map<List<ResultRoomDTO>>(popularRooms);

            return View("~/Views/Shared/_HomePopularRoomViewComponentPartial/Default.cshtml", model);
        }
    }
}
