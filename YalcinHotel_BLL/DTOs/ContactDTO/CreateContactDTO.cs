using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.ContactDTO
{
    public class CreateContactDTO
    {
        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Email en fazla 100 karakter olmalıdır.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu boş bırakılamaz.")]
        [StringLength(150, ErrorMessage = "Konu en fazla 150 karakter olmalıdır.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Mesaj en fazla 500 karakter olmalıdır.")]
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
