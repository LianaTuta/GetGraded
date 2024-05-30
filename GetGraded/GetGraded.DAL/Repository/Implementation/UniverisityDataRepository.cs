using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.DAL.Repository.Implementation
{
    public  class UniverisityDataRepository : IUniversityDataRepository
    {
        private readonly GetGradedContext _context;
        public UniverisityDataRepository(GetGradedContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentByUniversityId(int universityId)
        {
            var department = await _context.Department.Where(m => m.UniversityId == universityId).ToListAsync();
            return department;
        }

        public async Task<List<University>> GetUniversities()
        {
            return await  _context.University.ToListAsync();
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task<List<UniversityYear>> GetUniversityYears()
        {
            return await _context.UniversityYear.ToListAsync();
        }

        public async  Task<Department> GetDepartmentById(int id)
        {
            var department = await _context.Department.Where(m => m.Id == id).FirstOrDefaultAsync();
            return department;
        }
    }
}
