using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.CustomerDTO
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "E-Posta alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
