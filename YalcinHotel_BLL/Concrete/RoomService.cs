using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomService(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void Create(Room entity)
        {
            _roomDal.Create(entity);
        }

        public void Delete(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public List<Room> GetAll(Expression<Func<Room, bool>> filter = null)
        {
            return _roomDal.GetAll(filter);
        }

        public List<Room> GetPopularAll()
        {
            return _roomDal.GetAll(r => r.IsPopular && r.IsActive && r.IsAvailable); // Sadece aktif ve müsait popüler odaları getirir.
        }
        
        public Room GetById(int id)
        {
            return _roomDal.GetById(id);
        }

        public Room GetOne(Expression<Func<Room, bool>> filter = null)
        {
            return _roomDal.GetOne(filter);
        }

        public void Update(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}
