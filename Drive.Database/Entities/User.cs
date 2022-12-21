using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Drive.Database.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string DrivingSchool { get; set; }
        public long Points { get; set; }
        public List<Badges> Badges { get; set; } 
        public List<Question> ErrorQuestion { get; set; } 

        [JsonIgnore] public string PasswordHash { get; set; }
    }
}