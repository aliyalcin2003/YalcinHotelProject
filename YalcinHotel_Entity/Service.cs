using System;
using System.Collections.Generic;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Service : BaseEntity
    {
        public string Title { get; set; } // Odaların yanında sunulan hizmetlerin başlığı. Örn: Spa, Sauna, Fitness Center, Restaurant, Bar vb.
        public string Description { get; set; }
        public string IconUrl { get; set; } 
    }
}
