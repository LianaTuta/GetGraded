using GetGraded.Models.Models;

namespace GetGraded.DAL.Repository.Interface
{
    public interface IUserProfileRepository
    {
        Task<int> SaveUserProfile(UserProfile userProfile);

        Task SaveUserLoginDetails(UserLoginDetails userLoginDetails);
        Task<int> FindUserProfile(string email);
    }
}
