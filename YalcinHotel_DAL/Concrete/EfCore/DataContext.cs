using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YalcinHotel_Entity;

namespace YalcinHotel_DAL.Concrete.EfCore
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=YalcinHotelDB;Trusted_Connection=true;TrustServerCertificate=true");
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Keep the runtime model aligned with the migration snapshot. Existing
            // customer rows receive this value when the migration is applied.
            modelBuilder.Entity<Customer>() // ModelBuilder, Entity Framework Core'da veritabanı modelini yapılandırmak için kullanılan bir sınıftır. modelBuilder.Entity<Customer>() ifadesi, Customer entity'si için yapılandırma işlemlerini başlatır. Bu sayede, Customer entity'sine ait özellikler ve davranışlar üzerinde özelleştirmeler yapabiliriz.
                .Property(customer => customer.Role) // Property metodu, Customer entity'sinin Role property'sini yapılandırmak için kullanılır. Bu sayede, Role property'si üzerinde varsayılan değer atama gibi işlemler gerçekleştirebiliriz.
                .HasDefaultValue("Customer"); // hasDefaultValue metodu, veritabanına yeni bir kayıt eklendiğinde, Role property'si için varsayılan olarak "Customer" değerini atar. Bu sayede, eğer kullanıcı rolü belirtilmezse, otomatik olarak "Customer" rolü atanır.

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.IsAdminBootstrapped)
                .HasDefaultValue(false);
        }

    }
}

