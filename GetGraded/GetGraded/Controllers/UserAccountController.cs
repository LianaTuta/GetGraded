using GetGraded.BL.Services.Interface;
using GetGraded.Models;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetGraded.Controllers
{
    public class UserAccountController: Controller
    {
        private readonly IUserProfileSrvice _userProfileSrvice;

        private readonly ILogger<HomeController> _logger;

        public UserAccountController(ILogger<HomeController> logger, IUserProfileSrvice userProfileSrvice)
        {
            _logger = logger;
            _userProfileSrvice = userProfileSrvice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult FirstPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserProfileView userProfile)
        {
            await _userProfileSrvice.CreateAccount(userProfile);

            return RedirectToAction("Index", "Home");
        }
    }
}
