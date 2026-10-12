using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.SliderDTO;
namespace YalcinHotel_UI.ViewComponents.Home
{
    public class _HomeSliderViewComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public _HomeSliderViewComponentPartial(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _sliderService.GetOne(item => item.Page == "Home" && item.IsActive);
            var model = _mapper.Map<ResultSliderDTO>(slider);

            return View("~/Views/Shared/_HomeSliderViewComponentPartial/Default.cshtml", model);
        }
    }
}
