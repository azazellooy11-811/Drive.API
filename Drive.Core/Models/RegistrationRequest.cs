using System.ComponentModel.DataAnnotations;

namespace Drive.Core.Models
{
    public class RegistrationRequest
    {
        [Required] public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string City { get; set; }
        [Required] public string DrivingSchool { get; set; }
        [Required] public string PasswordHash { get; set; }
    }
}
