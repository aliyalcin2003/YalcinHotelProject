using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.ReservationDTO
{
    public class UpdateReservationDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Email en fazla 100 karakter olmalıdır.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olmalıdır.")]
        public string Phone { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        [StringLength(200, ErrorMessage = "Açıklama/Not en fazla 200 karakter olmalıdır.")]
        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
