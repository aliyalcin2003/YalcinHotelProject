namespace YalcinHotel_UI.Models
{
    public class CustomerManagementViewModel
    {
        public List<RegisteredCustomerRowViewModel> Customers { get; set; } = new();
    }

    public class RegisteredCustomerRowViewModel // Bu sınıf, kayıtlı müşterilerin bilgilerini temsil eder. Her bir müşteri için ad, e-posta, profil resmi URL'si, oluşturulma tarihi ve rezervasyon sayısı gibi bilgileri içerir.
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ReservationCount { get; set; }
    }

    public class CurrentGuestRowViewModel // Bu sınıf, şu anda otelde konaklayan misafirlerin bilgilerini temsil eder. Her bir misafir için ad, e-posta, telefon numarası, rezervasyon yapılan oda başlığı, giriş ve çıkış tarihleri ile konuk sayısı gibi bilgileri içerir.
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string RoomTitle { get; set; } = string.Empty;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestCount { get; set; }
    }
}
