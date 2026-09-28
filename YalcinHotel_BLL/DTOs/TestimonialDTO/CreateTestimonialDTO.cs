using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.TestimonialDTO
{
    public class CreateTestimonialDTO
    {
        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unvan boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Unvan en fazla 50 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yorum boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Yorum en fazla 500 karakter olmalıdır.")]
        public string Comment { get; set; }

        [StringLength(250, ErrorMessage = "Görsel yolu en fazla 250 karakter olmalıdır.")]
        public string ImageUrl { get; set; }
    }
}
