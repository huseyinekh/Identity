﻿using IdentityApp_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp_.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public MemberController(SignInManager<AppUser> signInManager)
        {

            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


    }
}
