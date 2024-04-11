using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.BL.Services.Implementation
{
    public class UserProfileService : IUserProfileSrvice
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileService(IUserProfileRepository userProfileRepository) {
            _userProfileRepository = userProfileRepository;
        }

        public async Task CreateAccount(UserProfileView userprofile)
        {
            
             await _userProfileRepository.SaveUserLoginDetails(new UserLoginDetails()
            {
                Email = userprofile.Email,
                Password = userprofile.Password
            });
            var id = await _userProfileRepository.FindUserProfile(userprofile.Email);
            await _userProfileRepository.SaveUserProfile(new UserProfile()
            {
                FirstName = userprofile.FirstName,
                MiddleName = userprofile.MiddleName,
                LastName = userprofile.LastName,
                BirthDate = userprofile.BirthDate,
                UserLoginId = id
            });
        }
    }
}
