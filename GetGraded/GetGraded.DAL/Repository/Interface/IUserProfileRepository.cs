using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.DAL.Repository.Interface
{
    public interface IUserProfileRepository
    {
        Task<int> SaveUserProfile(UserProfile userProfile);

        Task SaveUserLoginDetails(UserLoginDetails userLoginDetails);
        Task<int?> FindUserProfile(string email);
        Task SaveStudentDetails(StudentDetails studentDetails);
        Task<UserProfile> FindUserProfileById(int id);
        Task<StudentDetails> GetStudentDetailsByUserId(int userId);
        
    }

}
