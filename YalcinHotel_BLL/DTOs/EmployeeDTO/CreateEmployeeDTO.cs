using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.EmployeeDTO
{
    public class CreateEmployeeDTO
    {
        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olmalıdır.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Unvan alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Unvan en fazla 50 karakter olmalıdır.")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage = "Görsel yolu en fazla 250 karakter olmalıdır.")]
        public string ImageUrl { get; set; }

        public bool Status { get; set; } = true;

        [Required(ErrorMessage = "Hakkımızda ID alanı zorunludur.")]
        public int AboutId { get; set; }
    }
}
