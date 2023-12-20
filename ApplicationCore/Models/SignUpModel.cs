using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
	public class SignUpModel
	{
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}