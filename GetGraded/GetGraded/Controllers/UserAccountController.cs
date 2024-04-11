using GetGraded.BL.Services.Interface;
using GetGraded.Models;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetGraded.Controllers
{
    public class UserAccountController : Controller
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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(UserProfileView userLogin)
        {

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserLoginView userLogin)
        {

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserProfileView userProfile)
        {
            await _userProfileSrvice.CreateAccount(userProfile);

            return RedirectToAction(nameof(Login));
        }
    }
}