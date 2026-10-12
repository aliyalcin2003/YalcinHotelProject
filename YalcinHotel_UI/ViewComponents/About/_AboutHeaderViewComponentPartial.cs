using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.SliderDTO;
namespace YalcinHotel_UI.ViewComponents.About
{
    public class _AboutHeaderViewComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public _AboutHeaderViewComponentPartial(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _sliderService.GetOne(item => item.Page == "About" && item.IsActive);
            var model = _mapper.Map<ResultSliderDTO>(slider);

            return View("~/Views/Shared/_AboutHeaderViewComponentPartial/Default.cshtml", model);
        }
    }
}
