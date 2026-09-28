using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        public ServiceService(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Create(Service entity)
        {
            _serviceDal.Create(entity);
        }

        public void Delete(Service entity)
        {
            _serviceDal.Delete(entity);
        }

        public List<Service> GetAll(Expression<Func<Service, bool>> filter = null)
        {
            return _serviceDal.GetAll(filter);
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public Service GetOne(Expression<Func<Service, bool>> filter = null)
        {
            return _serviceDal.GetOne(filter);
        }

        public void Update(Service entity)
        {
            _serviceDal.Update(entity);
        }
    }
}
