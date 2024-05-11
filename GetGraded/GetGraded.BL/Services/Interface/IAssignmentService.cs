using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Interface
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetStudentAssignments(int userId);
    }
}
