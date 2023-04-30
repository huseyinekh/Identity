using IdentityApp_.Areas.Admin.Models;
using IdentityApp_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserList()
        {
            var userList = _userManager.Users.ToList();
            var userVievModel = userList.Select
                (x => new UserViewModel { Id = x.Id, Email = x.Email, Name = x.UserName }).ToList();
            return View(userVievModel);
        }
    }
}
