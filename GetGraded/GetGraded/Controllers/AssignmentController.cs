using GetGraded.BL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GetGraded.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;
       
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger, IAssignmentService assignmentService)
        {
            _logger = logger;
           _assignmentService = assignmentService;
        }
        public async Task<IActionResult> Index()
        {
            int userId = 3;
            var assignments = await _assignmentService.GetStudentAssignments(userId);
           
            return View(assignments);
        }
    }
}
