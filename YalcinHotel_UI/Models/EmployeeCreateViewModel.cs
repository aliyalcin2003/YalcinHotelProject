using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_UI.Models
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Çalışan adı zorunludur.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Çalışan soyadı zorunludur.")]
        [StringLength(100)]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Unvan zorunludur.")]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Çalışan fotoğrafı için internet adresi girin.")]
        [StringLength(2048)]
        public string ImageUrl { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Hakkımızda kaydı seçin.")]
        public int AboutId { get; set; }
    }
}
