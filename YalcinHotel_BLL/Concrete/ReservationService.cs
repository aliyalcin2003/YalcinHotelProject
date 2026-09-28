using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationService(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Create(Reservation entity)
        {
            _reservationDal.Create(entity);
        }

        public void Delete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public List<Reservation> GetAll(Expression<Func<Reservation, bool>> filter = null)
        {
            return _reservationDal.GetAll(filter);
        }

        public Reservation GetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public Reservation GetOne(Expression<Func<Reservation, bool>> filter = null)
        {
            return _reservationDal.GetOne(filter);
        }

        public void Update(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
