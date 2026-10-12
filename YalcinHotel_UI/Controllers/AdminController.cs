using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IServiceService _serviceService;
        private readonly ISliderService _sliderService;
        private readonly ITestimonialService _testimonialService;

        public AdminController(
            IContactService contactService,
            ICustomerService customerService,
            IEmployeeService employeeService,
            IReservationService reservationService,
            IRoomService roomService,
            IServiceService serviceService,
            ISliderService sliderService,
            ITestimonialService testimonialService)
        {
            _contactService = contactService;
            _customerService = customerService;
            _employeeService = employeeService;
            _reservationService = reservationService;
            _roomService = roomService;
            _serviceService = serviceService;
            _sliderService = sliderService;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var reservations = _reservationService.GetAll(item => item.IsActive);
            var model = new AdminDashboardViewModel
            {
                ActiveRoomCount = _roomService.GetAll(item => item.IsActive && item.IsAvailable).Count,
                ReservationCount = reservations.Count,
                PendingReservationCount = reservations.Count(item => item.Status == "Beklemede" || item.Status == "Onay Bekliyor"),
                CustomerCount = _customerService.GetAll(item => item.IsActive).Count,
                UnreadContactCount = _contactService.GetAll(item => item.IsActive && !item.IsRead).Count,
                ActiveEmployeeCount = _employeeService.GetAll(item => item.IsActive && item.Status).Count,
                ActiveServiceCount = _serviceService.GetAll(item => item.IsActive).Count,
                ActiveSliderCount = _sliderService.GetAll(item => item.IsActive).Count,
                ActiveTestimonialCount = _testimonialService.GetAll(item => item.IsActive).Count
            };

            return View(model);
        }
    }
}
