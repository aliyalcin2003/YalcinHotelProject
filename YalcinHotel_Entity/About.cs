using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_Entity
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<Employee> Employees { get; set; } // Employee entity'si ile ilişki kurmak için navigation property eklenmiştir. Bu sayede About entity'sine bağlı çalışanları listeleyebiliriz.
    }
}
        

        

        
