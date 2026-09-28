using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_UI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-posta adresinizi girin.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; } = string.Empty; // string.empty kullandım çünkü null olmasını istemiyorum. Kullanıcının şifresini sıfırlamak için e-posta adresini girmesi gereken alan. Bu alan, kullanıcının hesabına erişim sağlamak için gereklidir.
    }
}
