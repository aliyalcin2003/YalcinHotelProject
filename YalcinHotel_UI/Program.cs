using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_BLL.Concrete;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_DAL.Concrete.EfCore;
using YalcinHotel_Entity;
using YalcinHotel_UI.Mapping;

namespace YalcinHotel_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.Cookie.Name = "YalcinHotel.Auth";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromHours(8);
                });

            builder.Services.AddAutoMapper(cfg => { }, typeof(MapProfile));


            //Dependency Injection - Bağımlılık Yönetimi
            builder.Services.AddScoped<IAboutService, AboutService>();
            builder.Services.AddScoped<IAboutDal, EfCoreAboutDal>();

            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactDal, EfCoreContactDal>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeDal, EfCoreEmployeeDal>();

            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IReservationDal, EfCoreReservationDal>();

            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IRoomDal, EfCoreRoomDal>();

            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IServiceDal, EfCoreServiceDal>();

            builder.Services.AddScoped<ITestimonialService, TestimonialService>();
            builder.Services.AddScoped<ITestimonialDal, EfCoreTestimonialDal>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerDal, EfCoreCustomerDal>();

            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<ISliderDal, EfCoreSliderDal>();

            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactDal, EfCoreContactDal>();

            var app = builder.Build();

            EnsureDefaultAdmin(app);
            EnsureMangoPlantationService(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        private static void EnsureDefaultAdmin(WebApplication app)
        {
            var email = app.Configuration["Admin:Email"]?.Trim();
            var password = app.Configuration["Admin:Password"];
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Admin:Email ve Admin:Password ayarları tanımlanmalıdır.");

            using var scope = app.Services.CreateScope();
            var customers = scope.ServiceProvider.GetRequiredService<ICustomerService>();
            var admin = customers.GetAll()
                .FirstOrDefault(customer => string.Equals(customer.Email, email, StringComparison.OrdinalIgnoreCase));

            if (admin?.IsAdminBootstrapped == true)
                return;

            admin ??= new Customer { Email = email };
            admin.NameSurname = admin.NameSurname ?? "Yalçın Hotel Yönetici";
            admin.Role = "Admin";
            admin.IsActive = true;
            admin.Password = new PasswordHasher<Customer>().HashPassword(admin, password);
            admin.IsAdminBootstrapped = true;

            if (admin.Id == 0)
                customers.Create(admin);
            else
                customers.Update(admin);
        }

        private static void EnsureMangoPlantationService(WebApplication app)
        {
            const string title = "Mango Plantasyonu Gezileri";
            const string description = "Dutch van der Linde iş birliğiyle kurulan özel mango bahçelerimizi gezip taze meyvelerin tadını çıkarabileceğiniz eşsiz bir tur.";
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider.GetRequiredService<IServiceService>();
            var existing = services.GetAll()
                .FirstOrDefault(service => string.Equals(service.Title, title, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                if (existing.Description != description || existing.IconUrl != "fa-solid fa-seedling")
                {
                    existing.Description = description;
                    existing.IconUrl = "fa-solid fa-seedling";
                    services.Update(existing);
                }
                return;
            }

            services.Create(new Service
            {
                Title = title,
                Description = description,
                IconUrl = "fa-solid fa-seedling",
                IsActive = true
            });
        }
    }
}

            
            
          
