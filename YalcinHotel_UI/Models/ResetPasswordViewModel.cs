using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_UI.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yeni şifrenizi girin.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifreniz en az 8 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifrenizi tekrar girin.")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty; // string.empty kullandım çünkü null olmasını istemiyorum. ConfirmPassword, Password alanıyla eşleşmelidir.
    }
}
