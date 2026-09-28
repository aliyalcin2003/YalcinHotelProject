using System;
using System.Collections.Generic;
using System.Text;
using YalcinHotel_Entity;

namespace YalcinHotel_DAL.Abstract
{
    public interface IReservationDal : IRepository<Reservation>
    {
        // ileride müşteriye özel rezervasyonları listeleme metodu ekleyebilirsin. Ama şimdilik IGenericDal'daki metodlar yeterli. Reservation'a özel metod eklemeye gerek yok.
    }
}
