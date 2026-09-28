using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class SliderService : ISliderService
    {
        private readonly ISliderDal _sliderDal; 

        public SliderService(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Create(Slider entity)
        {
            _sliderDal.Create(entity);
        }

        public void Delete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public List<Slider> GetAll(Expression<Func<Slider, bool>> filter = null)
        {
            return _sliderDal.GetAll(filter);
        }

        public Slider GetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public Slider GetOne(Expression<Func<Slider, bool>> filter = null)
        {
            return _sliderDal.GetOne(filter);
        }

        public void Update(Slider entity) 
        {
            _sliderDal.Update(entity);
        }
    }
}
