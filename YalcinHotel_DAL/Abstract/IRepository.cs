using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace YalcinHotel_DAL.Abstract
{
    public interface IRepository<T> where T : class // Ortak bir interface oluşturduk. T tipi class olmak zorunda. Ortak olarak kullanılacak metodları buraya yazıyoruz(Eklemek, Güncellemek, Silmek). T tipi class olmak zorunda çünkü Entity Framework ile çalışacağız. Entity Framework class'lar üzerinden çalışır. T tipi class olmak zorunda çünki Entity Framework class'lar üzerinden çalışır.
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);
        T GetOne(Expression<Func<T, bool>> filter);
        T GetById(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
