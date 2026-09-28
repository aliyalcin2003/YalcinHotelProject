using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.SliderDTO;
using YalcinHotel_Entity;

namespace YalcinHotel_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _mapper = mapper;
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var slider = _sliderService.GetAll();
            return View(_mapper.Map<List<ResultSliderDTO>>(slider));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateSliderDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateSliderDTO dto)
        {
            if (!ImageMethods.IsExternalImageUrl(dto.ImageUrl1))
            {
                ModelState.AddModelError(nameof(dto.ImageUrl1), "Ana görsel için http veya https adresi giriniz.");
            }

            if (!ImageMethods.IsOptionalExternalImageUrl(dto.ImageUrl2))
            {
                ModelState.AddModelError(nameof(dto.ImageUrl2), "İkinci görsel için geçerli bir http veya https adresi giriniz.");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            dto.ImageUrl1 = ImageMethods.NormalizeImageUrl(dto.ImageUrl1);
            dto.ImageUrl2 = ImageMethods.NormalizeOptionalImageUrl(dto.ImageUrl2);
            _sliderService.Create(_mapper.Map<Slider>(dto));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var slider = _sliderService.GetById(id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UpdateSliderDTO>(slider));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateSliderDTO dto)
        {
            if (!ImageMethods.IsExternalImageUrl(dto.ImageUrl1))
            {
                ModelState.AddModelError(nameof(dto.ImageUrl1), "Ana görsel için http veya https adresi giriniz.");
            }

            if (!ImageMethods.IsOptionalExternalImageUrl(dto.ImageUrl2))
            {
                ModelState.AddModelError(nameof(dto.ImageUrl2), "İkinci görsel için geçerli bir http veya https adresi giriniz.");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var slider = _sliderService.GetById(dto.Id);
            if (slider == null)
            {
                return NotFound();
            }

            dto.ImageUrl1 = ImageMethods.NormalizeImageUrl(dto.ImageUrl1);
            dto.ImageUrl2 = ImageMethods.NormalizeOptionalImageUrl(dto.ImageUrl2);
            _mapper.Map(dto, slider);
            _sliderService.Update(slider);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var slider = _sliderService.GetById(id);
            if (slider == null)
                return NotFound();

            _sliderService.Delete(slider);
            TempData["SliderMessage"] = "Görsel kaydı silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
