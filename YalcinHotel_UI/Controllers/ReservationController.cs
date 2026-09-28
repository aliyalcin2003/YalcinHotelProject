using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.ReservationDTO;
using YalcinHotel_Entity;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservationService, IRoomService roomService, IMapper mapper, ILogger<ReservationController> logger)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _mapper = mapper;
            _logger = logger;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var values = _reservationService.GetAll(item => item.IsActive)
                .OrderByDescending(item => item.CreatedDate)
                .ToList();
            return View(values);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(int? roomId)
        {
            PopulateRooms(roomId);
            return View(new CreateReservationDTO
            {
                RoomId = roomId ?? 0,
                Name = User.FindFirstValue(ClaimTypes.Name) ?? string.Empty,
                Email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty
            });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateReservationDTO p)
        {
            if (p.CheckIn.Date < DateTime.Today)
                ModelState.AddModelError(nameof(p.CheckIn), "Giriş tarihi bugünden önce olamaz.");
            if (p.CheckOut.Date <= p.CheckIn.Date)
                ModelState.AddModelError(nameof(p.CheckOut), "Çıkış tarihi giriş tarihinden sonra olmalıdır.");

            var room = p.RoomId > 0 ? _roomService.GetById(p.RoomId) : null;
            if (room == null || !room.IsActive || !room.IsAvailable)
                ModelState.AddModelError(nameof(p.RoomId), "Seçtiğiniz oda şu anda müsait değil.");
            else if (p.GuestCount > room.Capacity)
                ModelState.AddModelError(nameof(p.GuestCount), $"Bu oda en fazla {room.Capacity} misafir ağırlayabilir.");

            if (!ModelState.IsValid)
            {
                PopulateRooms(p.RoomId);
                return View(p);
            }
            var value = _mapper.Map<Reservation>(p);
            value.CustomerName = User.FindFirstValue(ClaimTypes.Name) ?? p.Name.Trim();
            value.CustomerEmail = User.FindFirstValue(ClaimTypes.Email) ?? p.Email.Trim();
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var customerId))
                return Challenge();

            value.CustomerId = customerId;
            value.Status = "Onay Bekliyor";
            try
            {
                _reservationService.Create(value);
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError(exception, "Rezervasyon kaydı veritabanına yazılamadı.");
                ModelState.AddModelError(string.Empty, "Rezervasyon kaydı veritabanına yazılamadı. Veritabanını güncelleyin (Update-Database) ve tekrar deneyin.");
                PopulateRooms(p.RoomId);
                return View(p);
            }

            if (value.Id <= 0)
            {
                ModelState.AddModelError(string.Empty, "Rezervasyon numarası oluşturulamadı. Lütfen tekrar deneyin.");
                PopulateRooms(p.RoomId);
                return View(p);
            }

            return RedirectToAction(nameof(Confirmation), new { id = value.Id });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            var reservation = _reservationService.GetById(id);
            if (reservation == null)
                return NotFound();

            var email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            var currentCustomerId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var parsedCustomerId) ? parsedCustomerId : 0;
            var ownsReservation = reservation.CustomerId == currentCustomerId ||
                                  string.Equals(reservation.CustomerEmail, email, StringComparison.OrdinalIgnoreCase);
            if (!ownsReservation)
                return Forbid();

            return View(new ReservationConfirmationViewModel
            {
                ReservationId = reservation.Id,
                CheckIn = reservation.CheckInDate,
                CheckOut = reservation.CheckOutDate,
                GuestCount = reservation.GuestCount
            });
        }

        private void PopulateRooms(int? selectedRoomId = null)
        {
            ViewBag.Rooms = _roomService.GetAll(room => room.IsActive && room.IsAvailable)
                .OrderBy(room => room.Title)
                .Select(room => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = $"{room.Title} · {room.Price.ToString("C0")} / gece · {room.Capacity} kişi",
                    Selected = selectedRoomId == room.Id
                })
                .ToList();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _reservationService.GetById(id);
            if (value == null)
            {
                return NotFound(); 
            }
            var model = _mapper.Map<UpdateReservationDTO>(value); 
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateReservationDTO p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var value = _mapper.Map<Reservation>(p);
            _reservationService.Update(value);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            if (status is not ("Onaylandı" or "Reddedildi"))
                return BadRequest();

            var reservation = _reservationService.GetById(id);
            if (reservation == null)
                return NotFound();

            reservation.Status = status;
            _reservationService.Update(reservation);
            TempData["ReservationMessage"] = status == "Onaylandı"
                ? "Rezervasyon onaylandı."
                : "Rezervasyon reddedildi.";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var value = _reservationService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            _reservationService.Delete(value);
            return RedirectToAction("Index");
        }
    }
}

        
