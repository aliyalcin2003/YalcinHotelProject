using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.DTOs.ContactDTO;
using YalcinHotel_Entity;

namespace YalcinHotel_UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateContactDTO p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var value = _mapper.Map<Contact>(p);
            value.Date = DateTime.Now;
            _contactService.Create(value);
            TempData["ContactMessage"] = "Mesajınız bize ulaştı. En kısa sürede size dönüş yapacağız.";
            return RedirectToAction("Contact", "Home");
        }
    }
}
            
