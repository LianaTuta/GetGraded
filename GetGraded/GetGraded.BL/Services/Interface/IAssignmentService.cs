using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Interface
{
    public interface IAssignmentService
    {
        Task<List<AssignmentDetailsView>> GetAssignments(string userId, bool isCompleted);
        Task<AssignmentDetailsView> GetAssignmentsById(int id, int? answerId, string userId, bool isCompleted);
        Task SaveAnswer(int assignmentId, string userId, string path);

        Task UpdateAnwer(int score, int answerId, string userId);


    }
}
