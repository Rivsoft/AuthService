using System.ComponentModel.DataAnnotations;

namespace AuthService.API.Models
{
    public class CreateSessionTokenRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}