using System.Collections.Generic;
using Drive.Database.Entities;

namespace Drive.Core.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string DrivingSchool { get; set; }
        public long Points { get; set; }
        public List<Badges> Badge { get; set; }
        public List<Question> ErrorQuestion { get; set; }

        public string PasswordHash { get; set; }

        public static UserProfile FromUser(User user)
        {
            return new UserProfile()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Badge = user.Badges,
                City = user.City,
                DrivingSchool = user.DrivingSchool,
                Id = user.Id,
                Points = user.Points,
                ErrorQuestion = user.ErrorQuestion
                
            };
        }
    }
}
