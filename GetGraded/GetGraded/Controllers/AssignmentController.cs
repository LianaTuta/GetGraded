﻿

using GetGraded.BL.Services.Interface;
using GetGraded.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GetGraded.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AssignmentController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AssignmentController(ILogger<AssignmentController> logger,
            IAssignmentService assignmentService, UserManager<IdentityUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _assignmentService = assignmentService;
            _userManager = userManager;
          
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Overview()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var assignments = await _assignmentService.GetStudentAssignments(userId);
           
            return View(assignments);
        }

        [HttpGet]
        public async Task<IActionResult> AssignmentDetails(int assignmentId)
        {
           var model = await _assignmentService.GetAssignmentsById(assignmentId);
           return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>  UploadFile(IFormFile file, int id)
        {
            try
            {
               
                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    var filePath = Path.Combine(uploads,  file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    await _assignmentService.SaveAnswer(id, userId, file.FileName);
                    return Ok("File uploaded successfully!");
                }
                else
                {
                    return BadRequest("No file selected for upload.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }
    }
}