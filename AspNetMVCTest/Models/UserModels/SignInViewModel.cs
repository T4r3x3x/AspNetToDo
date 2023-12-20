using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Representation.Models.UserModels
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}