using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;

namespace GetGraded.BL.UserProfileStrategy.Implementation
{
    public class StudentProfileStrategy : IUserProfileStrategy
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public StudentProfileStrategy(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public async Task SaveAdditionalProperties(int userId, UserProfileView userProfileView)
        {
            await _userProfileRepository.SaveStudentDetails(new StudentDetails()
            {

            });
        }
    }
}
