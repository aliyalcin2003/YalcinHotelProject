using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.RoomDTO
{
    public class UpdateRoomDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Oda başlığı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Oda başlığı en fazla 100 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        public decimal Price { get; set; }

        [StringLength(250, ErrorMessage = "Görsel yolu en fazla 250 karakter olmalıdır.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Kapasite alanı zorunludur.")]
        [Range(1, 10, ErrorMessage = "Kapasite 1 ile 10 arasında olmalıdır.")]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }
        public bool IsActive { get; set; }
    }
}
