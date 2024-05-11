using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.DAL.Repository.Implementation
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly GetGradedContext _context;
        public AssignmentRepository(GetGradedContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignmentsByDepartmentIdUniversityYearId(int departmentId, int universityYearId)
        {
            return _context.Assignment.Where( a => a.DepartmentId == departmentId && 
            a.UniversityYearId == universityYearId && a.DeadLine> DateTime.Now).ToList();
        }
    }
}
