using YalcinHotel_BLL.DTOs.RoomDTO;

namespace YalcinHotel_UI.Models
{
    public class HomeRoomsViewModel
    {
        public List<ResultRoomDTO> Rooms { get; set; } = new();
        public bool PopularOnly { get; set; }
    }
}
