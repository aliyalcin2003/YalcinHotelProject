using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Contact : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(150)]
        public string Subject { get; set; }
        
        public string Message { get; set; }

        public DateTime Date { get; set; } = DateTime.Now; // Mesajın gönderildiği tarihi tutar. Default olarak mesaj gönderildiği anın tarihini alır.

        public bool IsRead { get; set; } = false; // Adminin mesajı okuduğunu anlamak için ekledik. Default olarak false yani okunmadı olarak başlatıyoruz.
    }
}
