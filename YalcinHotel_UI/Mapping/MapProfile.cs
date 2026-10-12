using AutoMapper;
using YalcinHotel_BLL.DTOs.AboutDTO;
using YalcinHotel_BLL.DTOs.ContactDTO;
using YalcinHotel_BLL.DTOs.CustomerDTO;
using YalcinHotel_BLL.DTOs.EmployeeDTO;
using YalcinHotel_BLL.DTOs.ReservationDTO;
using YalcinHotel_BLL.DTOs.RoomDTO;
using YalcinHotel_BLL.DTOs.ServiceDTO;
using YalcinHotel_BLL.DTOs.SliderDTO;
using YalcinHotel_BLL.DTOs.TestimonialDTO;
using YalcinHotel_Entity;

namespace YalcinHotel_UI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() // DTO kullanmak veri aktarımını sınırlar ve kontrol etmeye yardımcı olur; doğrulama ise DTO’daki kurallara ve uygulama koduna bağlıdır.
        {
            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();

            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();

            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, ResultEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();

            CreateMap<Room, CreateRoomDTO>().ReverseMap();
            CreateMap<Room, ResultRoomDTO>().ReverseMap();
            CreateMap<Room, UpdateRoomDTO>().ReverseMap();

            CreateMap<Reservation, CreateReservationDTO>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.CustomerName))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.CustomerEmail))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.CustomerPhone))
                .ForMember(d => d.CheckIn, o => o.MapFrom(s => s.CheckInDate))
                .ForMember(d => d.CheckOut, o => o.MapFrom(s => s.CheckOutDate)).ReverseMap();
            CreateMap<Reservation, ResultReservationDTO>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDTO>().ReverseMap();

            CreateMap<Service, ResultServiceDTO>().ReverseMap();
            CreateMap<Service, CreateServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDTO>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();

            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();
            CreateMap<Slider, CreateSliderDTO>().ReverseMap();


            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, ResultCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();

            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
        }
    }
}
            
            
            

