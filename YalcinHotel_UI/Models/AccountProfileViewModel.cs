using System.ComponentModel.DataAnnotations;
using YalcinHotel_Entity;

namespace YalcinHotel_UI.Models
{
    public class AccountProfileViewModel
    {
        [Required(ErrorMessage = "Adınızı ve soyadınızı girin.")]
        [StringLength(50)]
        public string NameSurname { get; set; } = string.Empty; // Kullanıcının adını ve soyadını saklamak için kullanılan alan. 

        [Url(ErrorMessage = "Profil görseli için geçerli bir URL girin.")]
        [StringLength(2048)]
        public string? ProfileImageUrl { get; set; } // Kullanıcının profil görseli için internet adresini saklamak için kullanılan alan. Bu alan isteğe bağlıdır ve geçerli bir URL olmalıdır.

        public string Email { get; set; } = string.Empty; // Kullanıcının e-posta adresini saklamak için kullanılan alan.

        public List<Reservation> Reservations { get; set; } = new(); // Kullanıcının yaptığı rezervasyonları saklamak için kullanılan liste.
    }
}
