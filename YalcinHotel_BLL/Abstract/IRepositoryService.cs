using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace YalcinHotel_BLL.Abstract
{
    public interface IRepositoryService<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetOne(Expression<Func<T, bool>> filter = null); // Veritabanından kritere uyan tek bir kaydı getirir; filtre verilmezse (null ise) tablodaki ilk kaydı döner.
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
        
