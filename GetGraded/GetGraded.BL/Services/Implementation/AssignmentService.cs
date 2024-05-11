using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Implementation
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository, IUserProfileRepository userProfileRepository) { 
            _assignmentRepository = assignmentRepository;
            _userProfileRepository = userProfileRepository;
        }
        public async Task<List<Assignment>> GetStudentAssignments(int userId)
        {
            var userProfile = await _userProfileRepository.FindUserProfileById(userId);
            var studentDetails = await _userProfileRepository.GetStudentDetailsByUserId(userId);
            return await  _assignmentRepository.GetAssignmentsByDepartmentIdUniversityYearId(userProfile.DepartmentId, studentDetails.UniversityYearId);
        }
    }
}
