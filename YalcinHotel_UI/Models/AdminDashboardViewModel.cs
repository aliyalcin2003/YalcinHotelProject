namespace YalcinHotel_UI.Models
{
    public class AdminDashboardViewModel // Bu sınıf, yönetici panelinde gösterilecek olan istatistiksel verileri temsil eder. Yönetici panelinde, otelin durumu hakkında hızlı bir genel bakış sağlamak için kullanılabilir. Bu sınıf, aktif oda sayısı, rezervasyon sayısı, bekleyen rezervasyon sayısı, müşteri sayısı, okunmamış iletişim sayısı, aktif çalışan sayısı, aktif hizmet sayısı, aktif slider sayısı, aktif referans sayısı ve aktif hakkımızda sayısı gibi bilgileri içerir.
    {
        public int ActiveRoomCount { get; set; }
        public int ReservationCount { get; set; }
        public int PendingReservationCount { get; set; }
        public int CustomerCount { get; set; }
        public int UnreadContactCount { get; set; }
        public int ActiveEmployeeCount { get; set; }
        public int ActiveServiceCount { get; set; }
        public int ActiveSliderCount { get; set; }
        public int ActiveTestimonialCount { get; set; }
        public int ActiveAboutCount { get; set; }
    }
}
