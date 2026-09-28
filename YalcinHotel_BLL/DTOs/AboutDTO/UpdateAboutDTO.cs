using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.AboutDTO
{
    public class UpdateAboutDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olmalıdır.")]
        public string Description { get; set; }

        [StringLength(250, ErrorMessage = "Görsel yolu en fazla 250 karakter olmalıdır.")]
        public string ImageUrl { get; set; }
    }
}
