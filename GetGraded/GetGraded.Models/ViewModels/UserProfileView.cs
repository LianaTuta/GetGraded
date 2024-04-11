using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.Models.ViewModels
{
    public class UserProfileView
    {
        [Required(ErrorMessage = "Please provide your first name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Please provide your last name", AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide your email", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide your password", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
