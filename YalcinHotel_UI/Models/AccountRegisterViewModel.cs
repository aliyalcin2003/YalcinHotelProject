using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_UI.Models
{
    public class AccountRegisterViewModel
    {
        [Required(ErrorMessage = "Adınızı ve soyadınızı girin.")]
        [StringLength(50, ErrorMessage = "Ad soyad en fazla 50 karakter olabilir.")]
        public string NameSurname { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta adresinizi girin.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre oluşturun.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifreniz en az 8 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifrenizi tekrar girin.")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty; // Kullanıcının şifreyi tekrar girmesi için kullanılan alan. ConfirmPassword, Password alanıyla eşleşmelidir.
    }
}
