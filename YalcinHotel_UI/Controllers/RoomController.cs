using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.RoomDTO;
using YalcinHotel_Entity;

namespace YalcinHotel_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var rooms = _roomService.GetAll().OrderByDescending(room => room.IsActive).ThenBy(room => room.Title);
            return View(_mapper.Map<List<ResultRoomDTO>>(rooms));
        }

        [HttpGet]
        public IActionResult Create() => View(new CreateRoomDTO());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateRoomDTO model)
        {
            if (!ImageMethods.IsExternalImageUrl(model.ImageUrl))
                ModelState.AddModelError(nameof(model.ImageUrl), "Oda görseli için http veya https adresi girin.");

            if (!ModelState.IsValid)
                return View(model);

            model.ImageUrl = ImageMethods.NormalizeImageUrl(model.ImageUrl);
            _roomService.Create(_mapper.Map<Room>(model));
            TempData["RoomMessage"] = "Yeni oda konaklama seçeneklerine eklendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = _roomService.GetById(id);
            return room == null ? NotFound() : View(_mapper.Map<UpdateRoomDTO>(room));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateRoomDTO model)
        {
            if (!ImageMethods.IsExternalImageUrl(model.ImageUrl))
                ModelState.AddModelError(nameof(model.ImageUrl), "Oda görseli için http veya https adresi girin.");

            if (!ModelState.IsValid)
                return View(model);

            var room = _roomService.GetById(model.Id);
            if (room == null)
                return NotFound();

            model.ImageUrl = ImageMethods.NormalizeImageUrl(model.ImageUrl);
            _mapper.Map(model, room);
            _roomService.Update(room);
            TempData["RoomMessage"] = "Oda bilgileri güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
                return NotFound();

            // Rezervasyonlardaki RoomId bağını korumak için odayı pasife alıyoruz.
            room.IsActive = false;
            room.IsAvailable = false;
            _roomService.Update(room);
            TempData["RoomMessage"] = "Oda sitede yayından kaldırıldı.";
            return RedirectToAction(nameof(Index));
        }
    }
}
