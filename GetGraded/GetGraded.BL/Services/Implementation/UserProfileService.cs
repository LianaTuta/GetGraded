using GetGraded.BL.Services.Interface;
using GetGraded.BL.UserProfileStrategy;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.BL.Services.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserProfileStrategy _userProfileStrategy;
        public UserProfileService(IUserProfileRepository userProfileRepository, IUserProfileStrategy userProfileStrategy)
        {
            _userProfileRepository = userProfileRepository;
            _userProfileStrategy = userProfileStrategy;
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
                UserLoginId = (int)id,
                RoleId = userprofile.RoleId,
                DepartmentId = userprofile.DepartmentId,
            });
            await _userProfileStrategy.SaveAdditionalProperties(id.Value, userprofile);
        }
        public async Task<bool> CheckEmailAvailability(string email)

        {
            var userProfile = await  _userProfileRepository.FindUserProfile(email);
            return userProfile == null ? false : true ;
        }
        public async Task UpdateAccountDetails(UserProfile userProfile)
        { 
            UserProfile userProfileModel = await _userProfileRepository.GetUserDetails(userProfile.Id);

            userProfileModel.FirstName = userProfile.FirstName;
            userProfileModel.MiddleName = userProfile.MiddleName;
            userProfileModel.LastName = userProfile.LastName;

            await _userProfileRepository.UpdateUserDetails(userProfileModel);
		}
        public async Task<UserProfile> GetUserProfileById (int id)
        {
			return await _userProfileRepository.FindUserProfileById(id);
		}

    }
        
}
