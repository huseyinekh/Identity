using IdentityApp_.Extensions;
using IdentityApp_.Models;
using IdentityApp_.ViewModels;
using IndentityApp_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IndentityApp_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(ILogger<HomeController> logger,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {

            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();

        }

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
            var identityResult = await _userManager.CreateAsync(new()
            {
                Email = request.Email,
                PhoneNumber = request.Phone,
                UserName = request.UserName,
            }, request.Password);
            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "Sign up is succeeded";

                return RedirectToAction(nameof(HomeController.SignUp));
            }
            ModelState.AddModelErrorList(
                identityResult.Errors.Select(x => x.Description).ToList());
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");
            if (!ModelState.IsValid)
            {
                return View();
            }
            var hasUser = await _userManager.FindByEmailAsync(model.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError("", "Email və ya password yanlışdır!!!");
                return View();
            }
            var res = await _signInManager.PasswordSignInAsync
                (hasUser, model
                .Password, model.RememberMe, true);
            if (res.Succeeded)
                return Redirect(returnUrl);

            if (res.IsLockedOut)
                ModelState.AddModelError("", "hesabınız 3 dəqiqəlik bloklandı");
            else
                ModelState.AddModelErrorList(new List<string>
                { "Email və ya password yanlışdır!!!" ,
                  $"Uğursuz cəhd sayı({await _userManager.GetAccessFailedCountAsync(hasUser)})"
                });
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}