using System.ComponentModel.DataAnnotations;

namespace Drive.Core.Models
{
    public class AuthenticateRequest
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}