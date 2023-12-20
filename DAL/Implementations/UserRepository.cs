using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
	public class UserRepository : IUserRepository
	{
		private readonly DataDbContext _dbContext;

		public UserRepository(DataDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAsync(User entity)
		{
			await _dbContext.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(User entity)
		{
			_dbContext.Persons.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public IQueryable<User> GetAll() => _dbContext.Persons;

		public async Task<User> GetAsync(int id)
		{
			var person = await _dbContext.Persons.Where(person => person.Id == id).FirstAsync();
			return person;
		}

		public Task<User> GetUserByEmailAsync(string email)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateAsync(User entity)
		{
			_dbContext.Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
