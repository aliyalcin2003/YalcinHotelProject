using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_DAL.Concrete.EfCore
{
    public class EfCoreAboutDal : EfCoreGenericRepository<About, DataContext>, IAboutDal
    {
        public About GetOne()
        {
            using (var context = new DataContext())
            {
                return context.Abouts.Include(i => i.Employees.Where(i => i.Status)).FirstOrDefault(); // About tablosundaki ilk kaydı getirir ve ilişkili Employee tablosundaki Status değeri true olanları filtreler.
            }
        }
    }
}
            

        
