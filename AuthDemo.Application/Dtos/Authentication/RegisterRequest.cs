using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Application.Dtos.Authentication
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
