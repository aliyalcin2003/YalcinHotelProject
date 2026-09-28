using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_UI.Models
{
    public class CreateTestimonialViewModel
    {
        [Required(ErrorMessage = "Lütfen yorumunuzu yazın.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Yorumunuz 10-500 karakter arasında olmalıdır.")]
        public string Comment { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "Puanınız 1 ile 5 arasında olmalıdır.")]
        public int Rating { get; set; } = 5;
    }
}
