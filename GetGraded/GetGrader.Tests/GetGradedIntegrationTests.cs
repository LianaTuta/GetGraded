using GetGraded.BL.Services.Implementation;
using GetGraded.BL.Services.Interface;
using GetGraded.BL.UserProfileStrategy;
using GetGraded.BL.UserProfileStrategy.Implementation;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetGrader.Tests
{
    public class GetGradedIntegrationTests
    {
        private Mock<IUserProfileRepository> userProfileRepositoryMock;
        private Mock<IAssignmentRepository> assignmentRepositoryMock;
        private Mock<IUniversityDataRepository> universityDataRepositoryMock;
        private Mock<IUserProfileStrategy> userProfileStrategyMock;
        private Mock<IUserEmailStore<IdentityUser>> _mockUserEmailStore;
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private Mock<SignInManager<IdentityUser>> _mockSignInManager;
        private StudentProfileStrategy studentProfileStrategy;

        private UserProfileService userProfileService;
        private UniversityDataService universityDataService;
        private AssignmentService assignmentService;
        private string existingUserId = "7d29748b-e5c9-41b6-8124-6f13a2aa3c5a";
        private string existingUserEmail = "testEmail@gmail.com";
        private int universityId = 1;

        [SetUp]
        public void SetUp()
        {
            userProfileRepositoryMock = new Mock<IUserProfileRepository>();
            assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            universityDataRepositoryMock = new Mock<IUniversityDataRepository>();
            userProfileStrategyMock = new Mock<IUserProfileStrategy>();

            universityDataRepositoryMock.Setup(repo => repo.GetDepartmentByUniversityId(universityId))
                .ReturnsAsync(GetMockDataForDepartments());
            universityDataRepositoryMock.Setup(repo => repo.GetDepartments())
                          .ReturnsAsync(GetMockDataForDepartments);
            universityDataRepositoryMock.Setup(repo => repo.GetUniversityYears())
                         .ReturnsAsync(GetMockDataForUniversityYears);
            universityDataRepositoryMock.Setup(repo => repo.GetRoles())
                 .ReturnsAsync(GetMockDataForRoles);
            universityDataRepositoryMock.Setup(repo => repo.GetUniversities())
                .ReturnsAsync(GetMockDataForUniversity);
            userProfileRepositoryMock.Setup(repo => repo.FindUserProfileByEmail(existingUserEmail))
                .ReturnsAsync(GetMockDataUserProfile());

            _mockUserEmailStore = new Mock<IUserEmailStore<IdentityUser>>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                _mockUserEmailStore.Object, null, null, null, null, null, null, null, null);

            // Mock UserManager to support email
            _mockUserManager.Setup(manager => manager.SupportsUserEmail).Returns(true);

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

            userProfileService = new UserProfileService(userProfileRepositoryMock.Object,
                userProfileStrategyMock.Object, _mockUserManager.Object, _mockUserEmailStore.Object, _mockSignInManager.Object);
            universityDataService = new UniversityDataService(universityDataRepositoryMock.Object);

            studentProfileStrategy = new StudentProfileStrategy(userProfileRepositoryMock.Object, assignmentRepositoryMock.Object);
            assignmentService = new AssignmentService(assignmentRepositoryMock.Object, userProfileRepositoryMock.Object, universityDataRepositoryMock.Object);
        }

        [Test]
        public async Task GetDepartmentByUniversityId_ReturnsDepartments_ForGivenUniversityId()
        {
            var expectedResult = GetMockDataForDepartments().OrderBy(d => d.Id);
            var result = (await universityDataService.GetDepartmentByUniversityId(universityId)).OrderBy(d => d.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(expectedResult.Count()));
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public async Task GetDepartments_ReturnsAllDepartments()
        {
            var expectedResult = GetMockDataForDepartments().OrderBy(d => d.Id);
            // Act
            var result = (await universityDataService.GetDepartments()).OrderBy(d => d.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(expectedResult.Count()));
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public async Task GetUniversities_ReturnsAllUniversities()
        {
            var expectedResult = GetMockDataForUniversity().ToList().OrderBy(d => d.Id);
            var result = (await universityDataService.GetUninversities()).ToList().OrderBy(d => d.Id);
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(expectedResult.Count()));
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public async Task GetRoles_ReturnsAllRoles()
        {
            var expectedResult = GetMockDataForRoles().ToList().OrderBy(d => d.Id);
            var result = (await universityDataService.GetRoles()).ToList().OrderBy(d => d.Id);
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(expectedResult.Count()));
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public async Task GetUniversityYears_ReturnsAllUniversityYears()
        {
            // Arrange
            var expectedResult = GetMockDataForUniversityYears().ToList().OrderBy(d => d.Id);
            var result = (await universityDataService.GetUniversityYears()).ToList().OrderBy(d => d.Id);
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(expectedResult.Count()));
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public async Task CheckEmailAvailability_UnUsedEmail_ReturnsFalse()
        {
            var unUsedEmail = "unusedemail@example.com";
            var result = await userProfileService.CheckEmailAvailability(unUsedEmail);
            Assert.False(result);
        }

        [Test]
        public async Task CheckEmailAvailability_AlreadyUsedEmail_ReturnsTrue()
        {
            var result = await userProfileService.CheckEmailAvailability(existingUserEmail);
            Assert.True(result);
        }

        [Test]
        public async Task CreateAccount_SuccessfulCreation_SavesUserProfileAndAdditionalProperties()
        {
            // Arrange
            var userProfileView = new UserProfileView
            {
                Email = "newuser@example.com",
                Password = "Password123!",
                FirstName = "John",
                MiddleName = "A",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                RoleId = 1,
                DepartmentId = 1
            };

            var user = new IdentityUser
            {
                Id = "newUserId",
                Email = userProfileView.Email
            };

            _mockUserEmailStore.Setup(store => store.SetUserNameAsync(It.IsAny<IdentityUser>(), userProfileView.Email, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _mockUserEmailStore.Setup(store => store.SetEmailAsync(It.IsAny<IdentityUser>(), userProfileView.Email, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _mockUserManager.Setup(manager => manager.CreateAsync(It.IsAny<IdentityUser>(), userProfileView.Password))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(manager => manager.GetUserIdAsync(It.IsAny<IdentityUser>()))
                .ReturnsAsync(user.Id);
          
            userProfileStrategyMock.Setup(strategy => strategy.SaveAdditionalProperties(user.Id, userProfileView))
                .Returns(Task.CompletedTask);

            // Act
            await userProfileService.CreateAccount(userProfileView);

            // Assert
            _mockUserEmailStore.Verify(store => store.SetUserNameAsync(It.IsAny<IdentityUser>(), userProfileView.Email, It.IsAny<CancellationToken>()), Times.Once);
            _mockUserEmailStore.Verify(store => store.SetEmailAsync(It.IsAny<IdentityUser>(), userProfileView.Email, It.IsAny<CancellationToken>()), Times.Once);
            _mockUserManager.Verify(manager => manager.CreateAsync(It.IsAny<IdentityUser>(), userProfileView.Password), Times.Once);
            _mockUserManager.Verify(manager => manager.GetUserIdAsync(It.IsAny<IdentityUser>()), Times.Once);
            userProfileRepositoryMock.Verify(repo => repo.SaveUserProfile(It.Is<UserProfile>(profile =>
                profile.FirstName == userProfileView.FirstName &&
                profile.MiddleName == userProfileView.MiddleName &&
                profile.LastName == userProfileView.LastName &&
                profile.BirthDate == userProfileView.BirthDate &&
                profile.AspNetUserId == user.Id &&
                profile.RoleId == userProfileView.RoleId &&
                profile.DepartmentId == userProfileView.DepartmentId)), Times.Once);
            userProfileStrategyMock.Verify(strategy => strategy.SaveAdditionalProperties(user.Id, userProfileView), Times.Once);
        }

        [Test]
        public void CreateAccount_FailedCreation_ThrowsException()
        {
            // Arrange
            var userProfileView = new UserProfileView
            {
                Email = "newuser@example.com",
                Password = "Password123!",
                FirstName = "John",
                MiddleName = "A",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                RoleId = 1,
                DepartmentId = 1
            };

            _mockUserEmailStore.Setup(store => store.SetUserNameAsync(It.IsAny<IdentityUser>(), userProfileView.Email, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _mockUserEmailStore.Setup(store => store.SetEmailAsync(It.IsAny<IdentityUser>(), userProfileView.Email, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _mockUserManager.Setup(manager => manager.CreateAsync(It.IsAny<IdentityUser>(), userProfileView.Password))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "User creation failed" }));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await userProfileService.CreateAccount(userProfileView));
            Assert.That(ex.Message, Is.EqualTo("Failed to save user account"));
        }
        [Test]
        public async Task SaveAnswer_SavesSubmittedAnswer()
        {
            // Arrange
            int assignmentId = 1;
            string userId = "userId";
            string path = "path/to/answer";

            assignmentRepositoryMock.Setup(repo => repo.SaveAnswer(It.IsAny<SubmittedAnswer>()))
                .Returns(Task.CompletedTask);

            // Act
            await assignmentService.SaveAnswer(assignmentId, userId, path);

            // Assert
            assignmentRepositoryMock.Verify(repo => repo.SaveAnswer(It.Is<SubmittedAnswer>(answer =>
                answer.AssignmentId == assignmentId &&
                answer.SubmitterId == userId &&
                answer.Path == path)), Times.Once);
        }

        [Test]
        public async Task UpdateAnswer_UpdatesAnswerAndSaves()
        {
            // Arrange
            int score = 10;
            int answerId = 1;
            string userId = "userId";

            var existingAnswer = new SubmittedAnswer
            {
                Id = answerId,
                Score = 5, // Original score
                ReviewerId = null // No reviewer initially
            };

            assignmentRepositoryMock.Setup(repo => repo.GetAnswerById(answerId))
                .ReturnsAsync(existingAnswer);

            assignmentRepositoryMock.Setup(repo => repo.SaveAnswer(It.IsAny<SubmittedAnswer>()))
                .Returns(Task.CompletedTask);

            // Act
            await assignmentService.UpdateAnwer(score, answerId, userId);

            // Assert
            assignmentRepositoryMock.Verify(repo => repo.GetAnswerById(answerId), Times.Once);
            assignmentRepositoryMock.Verify(repo => repo.SaveAnswer(It.Is<SubmittedAnswer>(answer =>
                answer.Id == answerId &&
                answer.Score == score &&
                answer.ReviewerId == userId)), Times.Once);
        }
 
        [Test]
        public async Task SaveAdditionalProperties_SavesStudentDetails()
        {
            // Arrange
            var userProfileView = new UserProfileView
            {
                Email = "newuser@example.com",
                UniversityYearId = 1
            };

            var userId = "newUserId";

            userProfileRepositoryMock.Setup(repo => repo.SaveStudentDetails(It.IsAny<StudentDetails>()))
                .Returns(Task.CompletedTask);

            // Act
            await studentProfileStrategy.SaveAdditionalProperties(userId, userProfileView);

            // Assert
            userProfileRepositoryMock.Verify(repo => repo.SaveStudentDetails(It.Is<StudentDetails>(details =>
                details.AspNetUserId == userId &&
                details.UniversityYearId == userProfileView.UniversityYearId)), Times.Once);
        }

        private IdentityUser? GetMockDataUserProfile()
        {
            IdentityUser? user = new IdentityUser
            {
                Id = existingUserId,
                Email = existingUserEmail,
            };
            return user;
        }

        private List<Department> GetMockDataForDepartments()
        {
            var expectedDepartments = new List<Department>
            {
                new Department { Id = 1, Name = "Computer Science" },
                new Department { Id = 2, Name = "Mathematics" }
            };
            return expectedDepartments;
        }

        private List<University> GetMockDataForUniversity()
        {
            var expectedUniversities = new List<University>
               {
                    new University { Id = 1, Name = "University A" },
                    new University { Id = 2, Name = "University B" }
               };
            return expectedUniversities;
        }
        private List<Role> GetMockDataForRoles()
        {
            var expectedRoles = new List<Role>
              {
                  new Role { Id = 1, Name = "Admin" },
                  new Role { Id = 2, Name = "User" }
              };
            return expectedRoles;
        }

        private List<UniversityYear> GetMockDataForUniversityYears()
        {
            var expectedYears = new List<UniversityYear>
            {
                new UniversityYear { Id = 1, Name = "1" },
                new UniversityYear { Id = 2, Name = "2" }
            };
            return expectedYears;
        }
    }
}
