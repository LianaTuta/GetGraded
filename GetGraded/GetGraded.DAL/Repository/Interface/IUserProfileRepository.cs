using GetGraded.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.DAL.Repository.Interface
{
    public interface IUserProfileRepository
    {
        Task<int> SaveUserProfile(UserProfile userProfile);

        Task SaveUserLoginDetails(UserLoginDetails userLoginDetails);
        Task<IdentityUser?> FindUserProfileByEmail(string email);
        Task SaveStudentDetails(StudentDetails studentDetails);
        Task<UserProfile> FindUserProfileById(string id);
        Task<StudentDetails> GetStudentDetailsByUserId(string userId);
        
    }

}
