using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.RoomDTO
{
    public class ResultRoomDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [StringLength(250)]
        public string ImageUrl { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }
        public bool IsActive { get; set; }
    }
}
