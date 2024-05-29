using GetGraded.BL.Services.Implementation;
using GetGraded.BL.Services.Interface;
using GetGraded.BL.UserProfileStrategy;
using GetGraded.BL.UserProfileStrategy.Implementation;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace GetGrader.Tests
{
    public class GetGradedIntegrationTests
    {
        private Mock<IUserProfileRepository> userProfileRepositoryMock;
        private Mock<IAssignmentRepository> assignmentRepositoryMock;
        private StudentProfileStrategy studentProfileStrategy;
        private Mock<IUserProfileStrategy> userProfileStrategy;
        private Mock<IUserStore<IdentityUser>> _mockUserStore;
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private Mock<SignInManager<IdentityUser>> _mockSignInManager;

        private UserProfileService userProfileService;
        private string existingUserId = "7d29748b-e5c9-41b6-8124-6f13a2aa3c5a";
        private string existingUserEmail = "testEmail@gmail.com";

        [SetUp]
        public void SetUp()
        {
            userProfileRepositoryMock = new Mock<IUserProfileRepository>();
            assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            userProfileRepositoryMock.Setup(repo => repo.FindUserProfileByEmail(existingUserEmail)).Returns(GetMockDataUserProfile());
            _mockUserStore = new Mock<IUserStore<IdentityUser>>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                _mockUserStore.Object, null, null, null, null, null, null, null, null);

            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<IdentityUser>>();
            var options = new Mock<IOptions<IdentityOptions>>();
            var logger = new Mock<ILogger<SignInManager<IdentityUser>>>();
            var schemes = new Mock<IAuthenticationSchemeProvider>();
            var confirmation = new Mock<IUserConfirmation<IdentityUser>>();

            _mockSignInManager = new Mock<SignInManager<IdentityUser>>(
                _mockUserManager.Object,
                contextAccessor.Object,
                userPrincipalFactory.Object,
                options.Object,
                logger.Object,
                schemes.Object,
                confirmation.Object);

            studentProfileStrategy = new StudentProfileStrategy(userProfileRepositoryMock.Object, assignmentRepositoryMock.Object);
            userProfileService = new UserProfileService(userProfileRepositoryMock.Object,
              null, _mockUserManager.Object, _mockUserStore.Object, _mockSignInManager.Object);
        }

     
        [Test]
        public  async Task CheckEmailAvailability_UnUsedEmail_ReturnsTrue()
        {

            var unUsedEmail = "email ";
            var result = await  userProfileService.CheckEmailAvailability(unUsedEmail);
            Assert.False(result);
        }

        [Test]
        public async Task CheckEmailAvailability_AlreadyUsedEmail_ReturnsFalse()
        {

           
            var result = await userProfileService.CheckEmailAvailability(existingUserEmail);
            Assert.True(result);
        }
        private async Task<IdentityUser?> GetMockDataUserProfile()
        {
            IdentityUser? user = new IdentityUser
            {
                Id = "7d29748b-e5c9-41b6-8124-6f13a2aa3c5a",
                Email = existingUserEmail,
                
            };
            return user;
        }

        
    }
}