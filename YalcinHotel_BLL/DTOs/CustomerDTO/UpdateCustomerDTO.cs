using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        [StringLength(50)]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "E-Posta alanı boş bırakılamaz.")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
