using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Customer : BaseEntity
    {
        [StringLength(50)]
        public string NameSurname { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Role { get; set; } = "Customer";

        public bool IsAdminBootstrapped { get; set; }

        public string? ProfileImageUrl { get; set; }
        
        public ICollection<Testimonial> Testimonials { get; set; }
    }
}

        
