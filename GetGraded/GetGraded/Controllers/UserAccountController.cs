using GetGraded.BL.Services.Interface;
using GetGraded.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace GetGraded.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserProfileService _userProfileSrvice;
        private readonly IUniversityDataService _universityDataService;

        private readonly ILogger<HomeController> _logger;

        public UserAccountController(ILogger<HomeController> logger, IUserProfileService userProfileSrvice, IUniversityDataService universityDataService)
        {
            _logger = logger;
            _userProfileSrvice = userProfileSrvice;
            _universityDataService = universityDataService;
        }


        public async Task<IActionResult> SignUp(UserProfileView userProfile)
        {

            userProfile.Universites = (await _universityDataService.GetUninversities()).ToList().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            userProfile.Roles = (await _universityDataService.GetRoles()).ToList().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            userProfile.UniversityYears = (await _universityDataService.GetUniversityYears()).ToList().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            userProfile.Departments = new List<SelectListItem>();
            return View(userProfile);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetDepartments(int universityId)
        {
            var departments = (await _universityDataService.GetDepartmentByUniversityId(universityId))
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            return Json(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmailAvailability(string email)
        {
           
            bool isEmailAvailable = await _userProfileSrvice.CheckEmailAvailability(email);
            return Json(new { available = !isEmailAvailable });
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAccount( UserProfileView userProfile)
        {
            await _userProfileSrvice.CreateAccount(userProfile);
            return RedirectToAction("Index", "Home");
        }
    }
}
