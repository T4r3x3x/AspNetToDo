using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
	internal class ProjectRepository : IRepository<Project>
	{
		private readonly DataDbContext _dataDbContext;

		public ProjectRepository(DataDbContext dataDbContext)
		{
			_dataDbContext = dataDbContext;
		}

		public async Task CreateAsync(Project entity)
		{
			_dataDbContext.Projects.Add(entity);
			await _dataDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(Project entity)
		{
			_dataDbContext.Projects.Remove(entity);
			await _dataDbContext.SaveChangesAsync();
		}

		public IQueryable<Project> GetAll() => _dataDbContext.Projects;

		public async Task<Project> GetAsync(int id)
		{
			var project = await _dataDbContext.Projects.Where(project => project.Id == id).FirstAsync();
			return project;
		}

		public async Task UpdateAsync(Project entity)
		{
			_dataDbContext.Projects.Update(entity);
			await _dataDbContext.SaveChangesAsync();
		}
	}
}
