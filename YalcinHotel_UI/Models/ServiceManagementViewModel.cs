using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_UI.Models
{
    public class ServiceManagementViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hizmet adı zorunludur.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty; // string.empty kullandım çünkü null olmasını istemiyorum. Hizmetin adını saklamak için kullanılan alan. Bu alan, hizmetin başlığını kullanıcıya sunmak için kullanılabilir.

        [Required(ErrorMessage = "Hizmet açıklaması zorunludur.")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty; // string.empty kullandım çünkü null olmasını istemiyorum. Hizmetin açıklamasını saklamak için kullanılan alan. Bu alan, hizmetin detaylarını kullanıcıya sunmak için kullanılabilir.

        [Required(ErrorMessage = "İkon sınıfını girin.")]
        [StringLength(100)]
        public string IconUrl { get; set; } = string.Empty; // string.empty kullandım çünkü null olmasını istemiyorum. Hizmetin ikonunu temsil eden URL'yi saklamak için kullanılan alan. Bu alan, hizmetin görsel temsilini kullanıcıya sunmak için kullanılabilir.
    }
}
