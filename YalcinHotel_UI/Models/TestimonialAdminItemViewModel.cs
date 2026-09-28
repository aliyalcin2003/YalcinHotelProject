using YalcinHotel_Entity;

namespace YalcinHotel_UI.Models
{
    public class TestimonialAdminItemViewModel
    {
        public Testimonial Testimonial { get; set; } = null!;
        public string CustomerName { get; set; } = string.Empty; // string.empty kullandım çünkü null olmasını istemiyorum. Müşterinin adını saklamak için kullanılan alan. Bu alan, müşterinin yorumunu kimin yazdığını belirtmek için kullanılabilir.
        public string? CustomerEmail { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
