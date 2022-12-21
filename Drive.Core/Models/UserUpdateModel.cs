using System.Collections.Generic;
using System.Text.Json.Serialization;
using Drive.Database.Entities;

namespace Drive.Core.Models
{
    public class UserUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string DrivingSchool { get; set; }
        public long Points { get; set; }
        public List<Question> ErrorQuestion { get; set; }

        public string PasswordHash { get; set; }
    }
}
