using GetGraded.Models.ViewModels;

namespace GetGraded.BL.Services.Interface
{
    public interface IUserProfileSrvice
    {
        Task CreateAccount(UserProfileView userprofile);
        Task UpdateAccountDetails(UserProfileView userprofile);
    }
}
