using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}