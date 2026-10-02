using System;
using System.Collections.Generic;
using System.Text;
using YalcinHotel_Entity;

namespace YalcinHotel_DAL.Abstract
{
    public interface IRoomDal : IRepository<Room>
    {
        // Belki canın isterse buraya Room'a özel metodlar ekleyebilirsin. Ama şimdilik IGenericDal'daki metodlar yeterli. Room'a özel metod eklemeye gerek yok.
    }
}
