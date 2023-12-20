using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		public Task<User> GetUserByEmailAsync(string email);
	}
}
