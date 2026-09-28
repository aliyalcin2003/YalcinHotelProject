using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Employee : BaseEntity
    {
        [StringLength(100)] 
        public string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }
        

        [StringLength(50)]
        public string Title { get; set; }
        
        public bool Status { get; set; }

        public string ImageUrl { get; set; }

        public int AboutId { get; set; }
        
        public About About { get; set; } // Çalışanın bağlı olduğu About entity'si ile ilişki kurmak için navigation property eklenmiştir.
    }
}
        
