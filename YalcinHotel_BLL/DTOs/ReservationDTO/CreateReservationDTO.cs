using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.ReservationDTO
{
    public class CreateReservationDTO
    {
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

        [Required(ErrorMessage = "Giriş tarihi zorunludur.")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Çıkış tarihi zorunludur.")]
        public DateTime CheckOut { get; set; }

        [Range(1, 10, ErrorMessage = "Misafir sayısı 1 ile 10 arasında olmalıdır.")]
        public int GuestCount { get; set; } = 2;

        [Range(1, int.MaxValue, ErrorMessage = "Lütfen konaklamak istediğiniz odayı seçin.")]
        public int RoomId { get; set; }

    }
}
