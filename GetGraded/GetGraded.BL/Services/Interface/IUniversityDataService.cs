using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Interface
{
    public interface IUniversityDataService
    {
        Task<List<Department>> GetDepartmentByUniversityId(int universityId);
        Task<List<Department>> GetDepartments();
        Task<List<University>> GetUninversities();
        Task<List<Role>> GetRoles();
        Task<List<UniversityYear>> GetUniversityYears();
    }
}
