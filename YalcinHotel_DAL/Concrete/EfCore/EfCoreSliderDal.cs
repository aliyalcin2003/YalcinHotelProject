using System;
using System.Collections.Generic;
using System.Text;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_DAL.Concrete.EfCore
{
    public class EfCoreSliderDal : EfCoreGenericRepository<Slider, DataContext>, ISliderDal
    {
    }
}
