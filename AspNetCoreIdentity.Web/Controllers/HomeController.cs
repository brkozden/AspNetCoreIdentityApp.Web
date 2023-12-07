using AspNetCoreIdentity.Web.Models;
using AspNetCoreIdentity.Web.ViewModels;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetCoreIdentity.Web.Extensions;
using AspNetCoreIdentity.Web.Services;

namespace AspNetCoreIdentity.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }


            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "Üst üste çok fazla yanlış giriş yaptınız. 3 dakika sonra yeniden deneyiniz." });
                return View();
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelErrorList(new List<string>() { $"Kullanıcı adı veya şifre yanlış." });
                return View();
            }




            return View();

        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identityResult = await _userManager.CreateAsync(new() { UserName = request.Username, Email = request.Email, PhoneNumber = request.Phone }, request.PasswordConfirm);
            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik kayıt işleminiz başarıyla gerçekleştirilmiştir.";
                return RedirectToAction(nameof(HomeController.SignUp));
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "Bu mail adresiyle ilişkili bir kayıt bulunamadı.");
                return View();
            }
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
            var passwordResetLink = Url.Action("ResetPassword", "Home", new { userID = hasUser.Id, Token = passwordResetToken }, HttpContext.Request.Scheme);
            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);
            TempData["success"] = "Şifre yenileme linki mail adresinize gönderilmiştir.";
            return RedirectToAction(nameof(ForgetPassword));

        }
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if (userId == null || token==null)
            {
              throw new Exception("Bir hata meydana geldi.");

            }

            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);
            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı bulunamadı.");
                return View();

            }
            IdentityResult result = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password!);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifre yenileme işleminiz tamamlanmıştır.";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
            }
                return View();
         
        }
    }
}