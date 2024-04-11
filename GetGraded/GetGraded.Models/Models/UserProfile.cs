using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.Models.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserLoginId { get; set; }
        public UserLoginDetails UserLogin { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
