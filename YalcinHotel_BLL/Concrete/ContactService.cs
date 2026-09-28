using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Create(Contact entity)
        {
            _contactDal.Create(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> GetAll(Expression<Func<Contact, bool>> filter = null)
        {
            return _contactDal.GetAll(filter);
        }
        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public Contact GetOne(Expression<Func<Contact, bool>> filter = null)
        {
            return _contactDal.GetOne(filter);
        }
        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
        

        

