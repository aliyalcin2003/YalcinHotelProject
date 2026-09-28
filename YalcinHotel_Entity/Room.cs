using Makaan_Entity;
using System.ComponentModel.DataAnnotations;

namespace YalcinHotel_Entity
{
    public class Room : BaseEntity
    {

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true; // Odanın Aktif olup olmadığını belirlemek için ekledik. Default olarak true yani aktif olarak başlatıyoruz.

        public string ImageUrl { get; set; }

        public int Capacity { get; set; }

        public bool IsPopular { get; set; } = false; // Odanın popüler olup olmadığını belirlemek için ekledik. Default olarak false yani popüler değil olarak başlatıyoruz.

        public ICollection<Reservation> Reservations { get; set; } // Resevation Class'ına referanstır. Bir odanın birden fazla rezervasyonu olabilir.
    }
        
}
        
        

        

        
        

