using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using YalcinHotel_Entity;

namespace Makaan_Entity
{
    public class Image : BaseEntity
    {
        public string Url { get; set; }

      
        public int RoomId { get; set; }
     
        public Room Room { get; set; } // room class'ına referanstır. Room class'ı ile bire çok ilişki kurmak için ekledik. Bir oda birden fazla resme sahip olabilir. Bu yüzden RoomId ve Room propertylerini ekledik.

        public Customer Customer { get; set; } // Customer class'ına referanstır. Custmer profil fotoğrafı için ekledik. Böylece bir müşteri profil fotoğrafı yükleyebilir. Customer class'ı ile bire bir ilişki kurmak için ekledik. Bir müşteri bir profil fotoğrafına sahip olabilir. Bu yüzden Customer propertylerini ekledik.
    }
}
        
