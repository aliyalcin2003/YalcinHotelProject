using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Testimonial : BaseEntity
    {
        public string ClientName { get; set; } // Müşteri adı soyadı örn: Ali Yalçın
        
        public string Title { get; set; } // Müşterinin yaptığı iş veya pozisyonu örn: Yazılım Geliştirici, CEO, CTO vb.
        
        [StringLength(500)]
        public string Comment { get; set; } 
        
        public string ImageUrl { get; set; }
        
        public int Rating { get; set; } // Müşterinin verdiği Yıldız sayısı. 1 ile 5 arasında bir değer alabilir.

        public int CustomerId { get; set; } 

        public Customer Customer { get; set; } 
    }
}
