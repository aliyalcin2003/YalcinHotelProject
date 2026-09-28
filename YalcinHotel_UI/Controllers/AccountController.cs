using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_Entity;
using YalcinHotel_UI.Models;

namespace YalcinHotel_UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IReservationService _reservationService;
        private readonly PasswordHasher<Customer> _passwordHasher = new();
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _resetTokenProtector;
        private readonly IWebHostEnvironment _environment;

        public AccountController(ICustomerService customerService, IReservationService reservationService, IConfiguration configuration, IDataProtectionProvider dataProtectionProvider, IWebHostEnvironment environment)
        {
            _customerService = customerService;
            _reservationService = reservationService;
            _configuration = configuration;
            _resetTokenProtector = dataProtectionProvider.CreateProtector("YalcinHotel.Account.PasswordReset.v1");
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return LocalRedirect(returnUrl);

                return User.IsInRole("Admin")
                    ? RedirectToAction("Index", "Admin")
                    : RedirectToAction("Index", "Home");
            }

            return View(new AccountLoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var customer = _customerService.GetAll()
                .FirstOrDefault(item => string.Equals(item.Email, model.Email.Trim(), StringComparison.OrdinalIgnoreCase) && item.IsActive);

            if (customer == null || !VerifyPassword(customer, model.Password, out var needsRehash))
            {
                ModelState.AddModelError(string.Empty, "E-posta adresi veya şifre hatalı.");
                return View(model);
            }

            if (needsRehash)
            {
                customer.Password = _passwordHasher.HashPassword(customer, model.Password);
                _customerService.Update(customer);
            }

            var adminEmail = _configuration["Admin:Email"];
            if (!string.IsNullOrWhiteSpace(adminEmail) && string.Equals(customer.Email, adminEmail, StringComparison.OrdinalIgnoreCase) && customer.Role != "Admin")
            {
                customer.Role = "Admin";
                _customerService.Update(customer);
            }

            await SignInCustomer(customer, model.RememberMe);
            if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                return LocalRedirect(model.ReturnUrl);

            return customer.Role == "Admin"
                ? RedirectToAction("Index", "Admin")
                : RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home");

            return View(new AccountRegisterViewModel());
        }

        [HttpGet]
        public IActionResult ForgotPassword() => View(new ForgotPasswordViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            TempData["PasswordResetMessage"] = "Bu e-posta adresi kayıtlıysa şifre yenileme bağlantısı hazırlanmıştır.";
            var customer = _customerService.GetAll()
                .FirstOrDefault(item => item.IsActive && string.Equals(item.Email, model.Email.Trim(), StringComparison.OrdinalIgnoreCase));
            if (customer != null)
            {
                var expires = DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds();
                var protectedToken = _resetTokenProtector.Protect($"{customer.Id}|{expires}|{customer.Password}");
                var token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(protectedToken));
                var resetUrl = Url.Action(nameof(ResetPassword), "Account", new { token }, Request.Scheme)!;
                var sent = await SendResetEmailAsync(customer, resetUrl);

                // This local preview keeps password recovery usable during development without SMTP.
                if (!sent && _environment.IsDevelopment())
                    TempData["DevelopmentResetLink"] = resetUrl;
            }

            return RedirectToAction(nameof(ForgotPassword));
        }

        [HttpGet]
        public IActionResult ResetPassword(string? token)
        {
            if (string.IsNullOrWhiteSpace(token) || GetResetCustomer(token) == null)
                return View("ResetPasswordInvalid");

            return View(new ResetPasswordViewModel { Token = token });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            var customer = GetResetCustomer(model.Token);
            if (customer == null)
                return View("ResetPasswordInvalid");

            if (!ModelState.IsValid)
                return View(model);

            customer.Password = _passwordHasher.HashPassword(customer, model.Password);
            var adminEmail = _configuration["Admin:Email"];
            if (!string.IsNullOrWhiteSpace(adminEmail) && string.Equals(customer.Email, adminEmail, StringComparison.OrdinalIgnoreCase))
            {
                customer.Role = "Admin";
                customer.IsAdminBootstrapped = true;
            }
            _customerService.Update(customer);
            TempData["PasswordResetMessage"] = "Şifreniz yenilendi. Yeni şifrenizle giriş yapabilirsiniz.";
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var email = model.Email.Trim();
            var exists = _customerService.GetAll()
                .Any(item => string.Equals(item.Email, email, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Email), "Bu e-posta adresiyle zaten bir hesap var.");
                return View(model);
            }

            var adminEmail = _configuration["Admin:Email"];
            var customer = new Customer
            {
                NameSurname = model.NameSurname.Trim(),
                Email = email,
                Role = !string.IsNullOrWhiteSpace(adminEmail) && string.Equals(email, adminEmail, StringComparison.OrdinalIgnoreCase) ? "Admin" : "Customer",
                IsActive = true
            };
            customer.Password = _passwordHasher.HashPassword(customer, model.Password);
            _customerService.Create(customer);
            await SignInCustomer(customer, rememberMe: false);

            return customer.Role == "Admin"
                ? RedirectToAction("Index", "Admin")
                : RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var customer = GetCurrentCustomer();
            if (customer == null)
                return Challenge();

            return View(new AccountProfileViewModel
            {
                NameSurname = customer.NameSurname,
                Email = customer.Email,
                ProfileImageUrl = customer.ProfileImageUrl,
                Reservations = _reservationService.GetAll(item => item.IsActive &&
                    (item.CustomerId == customer.Id || item.CustomerEmail.Trim().ToLower() == customer.Email.Trim().ToLower()))
                    .OrderByDescending(item => item.CreatedDate)
                    .ToList()
            });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(AccountProfileViewModel model)
        {
            var customer = GetCurrentCustomer();
            if (customer == null)
                return Challenge();

            if (!string.IsNullOrWhiteSpace(model.ProfileImageUrl) && !IsHttpUrl(model.ProfileImageUrl))
                ModelState.AddModelError(nameof(model.ProfileImageUrl), "Profil görseli http veya https adresi olmalıdır.");

            if (!ModelState.IsValid)
            {
                model.Email = customer.Email;
                model.Reservations = _reservationService.GetAll(item => item.IsActive &&
                    (item.CustomerId == customer.Id || item.CustomerEmail.Trim().ToLower() == customer.Email.Trim().ToLower()))
                    .OrderByDescending(item => item.CreatedDate)
                    .ToList();
                return View(model);
            }

            customer.NameSurname = model.NameSurname.Trim();
            customer.ProfileImageUrl = string.IsNullOrWhiteSpace(model.ProfileImageUrl) ? null : model.ProfileImageUrl.Trim();
            _customerService.Update(customer);
            await SignInCustomer(customer, rememberMe: true);
            TempData["AccountMessage"] = "Profil bilgileriniz güncellendi.";
            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();

        private Customer? GetCurrentCustomer()
        {
            var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(idValue, out var id) ? _customerService.GetById(id) : null;
        }

        private Customer? GetResetCustomer(string token)
        {
            try
            {
                var protectedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                var payload = _resetTokenProtector.Unprotect(protectedToken).Split('|', 3);
                if (payload.Length != 3 || !int.TryParse(payload[0], out var id) ||
                    !long.TryParse(payload[1], out var expires) || expires < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                    return null;

                var customer = _customerService.GetById(id);
                return customer != null && customer.IsActive && string.Equals(customer.Password, payload[2], StringComparison.Ordinal)
                    ? customer
                    : null;
            }
            catch (Exception exception) when (exception is FormatException or CryptographicException or ArgumentException)
            {
                return null;
            }
        }

        private async Task<bool> SendResetEmailAsync(Customer customer, string resetUrl)
        {
            var host = _configuration["Email:Smtp:Host"];
            var from = _configuration["Email:From"];
            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(from) ||
                !int.TryParse(_configuration["Email:Smtp:Port"], out var port))
                return false;

            using var message = new MailMessage(from, customer.Email)
            {
                Subject = "Yalçın Hotel şifre yenileme",
                Body = $"Merhaba {WebUtility.HtmlEncode(customer.NameSurname)},<br/><br/>Şifrenizi yenilemek için <a href=\"{WebUtility.HtmlEncode(resetUrl)}\">bu bağlantıyı açın</a>. Bağlantı 30 dakika geçerlidir.",
                IsBodyHtml = true
            };
            using var client = new SmtpClient(host, port)
            {
                EnableSsl = string.Equals(_configuration["Email:Smtp:EnableSsl"], "true", StringComparison.OrdinalIgnoreCase)
            };
            var username = _configuration["Email:Smtp:Username"];
            var password = _configuration["Email:Smtp:Password"];
            if (!string.IsNullOrWhiteSpace(username))
                client.Credentials = new NetworkCredential(username, password);

            try
            {
                await client.SendMailAsync(message);
                return true;
            }
            catch (SmtpException)
            {
                return false;
            }
        }

        private bool VerifyPassword(Customer customer, string password, out bool needsRehash)
        {
            needsRehash = false;
            try
            {
                var result = _passwordHasher.VerifyHashedPassword(customer, customer.Password, password);
                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                    needsRehash = true;
                return result != PasswordVerificationResult.Failed;
            }
            catch (FormatException)
            {
                // Eski kayıtlardaki düz metin parolalar başarılı girişten sonra hashlenir.
            }

            if (string.Equals(customer.Password, password, StringComparison.Ordinal))
            {
                needsRehash = true;
                return true;
            }

            return false;
        }

        private async Task SignInCustomer(Customer customer, bool rememberMe)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new(ClaimTypes.Name, customer.NameSurname),
                new(ClaimTypes.Email, customer.Email),
                new(ClaimTypes.Role, customer.Role)
            };
            if (!string.IsNullOrWhiteSpace(customer.ProfileImageUrl))
                claims.Add(new Claim("profile_image", customer.ProfileImageUrl));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties { IsPersistent = rememberMe, AllowRefresh = true });
        }

        private static bool IsHttpUrl(string value) =>
            Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}
