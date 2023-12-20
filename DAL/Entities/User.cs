using DAL.Enum;
namespace DAL.Entities
{
	public class User
	{
		public long Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
	}
}
