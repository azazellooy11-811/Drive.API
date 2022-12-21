using Drive.Database.Entities;

namespace Drive.API.Models
{
    public class UserDto
    {
        public UserDto(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            City = user.City;
            DrivingSchool = user.DrivingSchool;
            Token = token;
            Points = user.Points;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string DrivingSchool { get; set; }
        public string Token { get; set; }
        public long Points { get; set; }
        public object Password { get; internal set; }
    }
}