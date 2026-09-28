using System;
using System.Collections.Generic;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Reservation : BaseEntity
    {
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
        
        public string CustomerPhone { get; set; }
        
        public DateTime CheckInDate { get; set; } 
        
        public DateTime CheckOutDate { get; set; } 
        
        public int GuestCount { get; set; }
        
        public string Status { get; set; } = "Beklemede"; // Onaylandı, İptal Edildi Sonuçlarını Anında veremeyeceğimiz için Beklemede olarak başlatıyoruz.

        public int RoomId { get; set; }

        // Stable account link for profile reservation history; null for legacy rows.
        public int? CustomerId { get; set; }
        
        public Room Room { get; set; } // Room Class'ına referanstır.
    }
}

