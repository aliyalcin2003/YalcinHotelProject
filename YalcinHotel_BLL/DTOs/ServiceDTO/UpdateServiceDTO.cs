using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.ServiceDTO
{
    public class UpdateServiceDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(300, ErrorMessage = "Açıklama en fazla 300 karakter olmalıdır.")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "İkon alanı en fazla 100 karakter olmalıdır.")]
        public string Icon { get; set; }
    }
}
