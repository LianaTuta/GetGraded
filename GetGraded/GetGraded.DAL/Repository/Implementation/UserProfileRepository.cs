using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.DAL.Repository.Implementation
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly GetGradedContext _context;
        public UserProfileRepository(GetGradedContext context)
        {
            _context = context;
        }

        public async Task<int> SaveUserProfile(UserProfile userProfile)
        {
          
            await _context.UserProfile.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile.Id;
        }

        public async Task SaveUserLoginDetails(UserLoginDetails userLoginDetails)
        {
            await _context.UserLoginDetails.AddAsync(userLoginDetails);
            await _context.SaveChangesAsync();
         
        }

        public async Task<int> FindUserProfile(string email)
        {
            var userProfile = await  _context.UserLoginDetails.FirstOrDefaultAsync(m => m.Email ==email);
            return userProfile.Id;
        }

        public async Task<UserProfile> GetUserDetails(int userProfileId)
        {
            var userProfile = await _context.UserProfile.FirstOrDefaultAsync(user => user.Id == userProfileId);

            return userProfile;
        }

        public async Task UpdateUserDetails(UserProfile userProfile)
        {
            _context.UserProfile.Update(userProfile);
            await _context.SaveChangesAsync();
        }
    }
}
