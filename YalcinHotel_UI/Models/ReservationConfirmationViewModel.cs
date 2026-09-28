namespace YalcinHotel_UI.Models
{
    public class ReservationConfirmationViewModel // rezervasyonları onaylamak için kullanılan bir ViewModel sınıfıdır. Bu sınıf, rezervasyonun kimliği, giriş ve çıkış tarihleri ile konuk sayısı gibi bilgileri içerir. Bu bilgiler, kullanıcıya rezervasyonun detaylarını göstermek için kullanılabilir.
    {
        public int ReservationId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestCount { get; set; }
    }
}
