﻿using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GetGraded.DAL.Repository.Interface
{
    public interface IUserProfileRepository
    {
        Task<int> SaveUserProfile(UserProfile userProfile);

        Task SaveUserLoginDetails(UserLoginDetails userLoginDetails);
        Task<int?> FindUserProfile(string email);
        Task SaveStudentDetails(StudentDetails studentDetails);
        Task<UserProfile> FindUserProfileById(string id);
        Task<StudentDetails> GetStudentDetailsByUserId(string userId);
		Task<UserProfile> GetUserDetails(int userProfileId);
		Task UpdateUserDetails(UserProfile userProfile);
	}

}
