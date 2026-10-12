using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.AboutDTO;
namespace YalcinHotel_UI.ViewComponents.Home
{
    // Ana sayfadaki Hakkımızda bölümüne aktif içerikleri getirip DTO listesi sağlar.
    public class _HomeAboutViewComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public _HomeAboutViewComponentPartial(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var aboutList = _aboutService.GetAll(item => item.IsActive);
            var model = _mapper.Map<List<ResultAboutDTO>>(aboutList);

            return View("~/Views/Shared/_HomeAboutViewComponentPartial/Default.cshtml", model);
        }
    }
}
