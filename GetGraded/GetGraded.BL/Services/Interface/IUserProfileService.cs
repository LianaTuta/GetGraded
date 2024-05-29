using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;

namespace GetGraded.BL.Services.Interface
{
    public interface IUserProfileService
    {
        Task CreateAccount(UserProfileView userprofile);
        Task<bool> CheckEmailAvailability(string email);
        Task UpdateAccountDetails(UserProfile userprofile);
        Task<UserProfile> GetUserProfileById(string id);

	}
}
