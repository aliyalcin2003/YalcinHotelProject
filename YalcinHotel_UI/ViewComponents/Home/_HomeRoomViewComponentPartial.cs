using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.RoomDTO;
using YalcinHotel_UI.Models;
namespace YalcinHotel_UI.ViewComponents.Home
{
    public class _HomeRoomViewComponentPartial : ViewComponent
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public _HomeRoomViewComponentPartial(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(bool popularOnly = false)
        {
            var rooms = _roomService.GetAll(item => item.IsActive && item.IsAvailable && (!popularOnly || item.IsPopular));
            var model = new HomeRoomsViewModel
            {
                Rooms = _mapper.Map<List<ResultRoomDTO>>(rooms),
                PopularOnly = popularOnly
            };

            return View("~/Views/Shared/_HomeRoomViewComponentPartial/Default.cshtml", model);
        }
    }
}
