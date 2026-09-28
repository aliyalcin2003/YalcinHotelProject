using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;

        public CustomerController(ICustomerService customerService, IReservationService reservationService, IRoomService roomService)
        {
            _customerService = customerService;
            _reservationService = reservationService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var reservations = _reservationService.GetAll(item => item.IsActive);
            var customers = _customerService.GetAll(item => item.IsActive && item.Role != "Admin")
                .OrderByDescending(item => item.CreatedDate)
                .Select(customer => new RegisteredCustomerRowViewModel
                {
                    Id = customer.Id,
                    Name = customer.NameSurname,
                    Email = customer.Email,
                    ProfileImageUrl = customer.ProfileImageUrl,
                    CreatedDate = customer.CreatedDate,
                    ReservationCount = reservations.Count(reservation =>
                        reservation.CustomerId == customer.Id ||
                        string.Equals(reservation.CustomerEmail, customer.Email, StringComparison.OrdinalIgnoreCase))
                })
                .ToList();

            return View(new CustomerManagementViewModel { Customers = customers });
        }

        public IActionResult Staying()
        {
            var today = DateTime.Today;
            var stays = _reservationService.GetAll(item => item.IsActive &&
                    item.Status == "Onaylandı" && item.CheckInDate < today.AddDays(1) && item.CheckOutDate > today)
                .OrderBy(item => item.CheckOutDate)
                .Select(reservation => new CurrentGuestRowViewModel
                {
                    Name = reservation.CustomerName,
                    Email = reservation.CustomerEmail,
                    Phone = reservation.CustomerPhone,
                    RoomTitle = _roomService.GetById(reservation.RoomId)?.Title ?? $"Oda #{reservation.RoomId}",
                    CheckIn = reservation.CheckInDate,
                    CheckOut = reservation.CheckOutDate,
                    GuestCount = reservation.GuestCount
                })
                .ToList();

            return View(stays);
        }
    }
}
