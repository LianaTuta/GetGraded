using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUniversityDataRepository _universityDataRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository, 
            IUserProfileRepository userProfileRepository,
            IUniversityDataRepository universityDataRepository ) { 
            _assignmentRepository = assignmentRepository;
            _userProfileRepository = userProfileRepository;
            _universityDataRepository = universityDataRepository;
        }
        public async Task<List<Assignment>> GetStudentAssignments(string  userId)
        {
            var userProfile = await _userProfileRepository.FindUserProfileById(userId);
            var studentDetails = await _userProfileRepository.GetStudentDetailsByUserId(userId);
            
            var assignments = await  _assignmentRepository.GetAssignmentsByDepartmentIdUniversityYearId(userProfile.DepartmentId, studentDetails.UniversityYearId);
            foreach ( var assignment in assignments )
            {
                assignment.Department = await _universityDataRepository.GetDepartmentById(assignment.DepartmentId);
            }
            return assignments;
        }

        public  async Task<Assignment> GetAssignmentsById(int id)
        {
            return await _assignmentRepository.GetAssignmentsById(id);
        }

        public async Task SaveAnswer(int assignmentId, string userId, string path)
        {
             await _assignmentRepository.SaveAnswer(new SubmittedAnswer()
            {
                 AssignmentId = assignmentId,
                 SubmitterId = userId,
                 Path = path
             });
        }
    }
}
