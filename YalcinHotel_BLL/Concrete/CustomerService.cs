using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Create(Customer entity)
        {
            _customerDal.Create(entity);
        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetAll(filter);
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public Customer GetOne(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetOne(filter);
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
