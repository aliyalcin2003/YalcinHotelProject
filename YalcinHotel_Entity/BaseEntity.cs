using System;
using System.Collections.Generic;
using System.Text;

namespace YalcinHotel_Entity
{
    public abstract class BaseEntity // abstarct kullanıldı çünkü bu sınıftan nesne oluşturulamasını istemiyorum. Sadece miras alınabilir olsun istedim.
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Nesne oluşturulduğu anın tarihini alır.

        public bool IsActive { get; set; } = true; // Nesne aktif mi değil mi bilgisini tutar. Default olarak true atanır.
    }
}
