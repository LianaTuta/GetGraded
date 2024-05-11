using GetGraded.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.UserProfileStrategy
{
    public interface IUserProfileStrategy
    {
        Task SaveAdditionalProperties(int userId, UserProfileView userProfileView);
    }
}
