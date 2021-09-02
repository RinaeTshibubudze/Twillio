using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TwilioSMS2.Models;

namespace TwilioSMS2.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            ViewData["Users"] = await _userManager.Users.ToListAsync();
            return View();
        }
    }
}
