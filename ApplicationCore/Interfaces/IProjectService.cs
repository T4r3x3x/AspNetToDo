using DAL.Entities;
using DAL.Enum;
using System.Reflection.Emit;

namespace ApplicationCore.Interfaces
{
	public interface IProjectService
	{
		public Task CreateAsync(Project project);
		public Task UpdateAsync(Project project);
		public Task AddTaskAsync(Task task);
		public Task DeleteTaskAsync(Task task);
		public Task UpdateTaskAsync(Task task);
		public Task GetTaskAsync(Task task);
		public Task GetAllTask();
		public Task ChangeUserRoleAsync(User user, Role newRole);
		public Task KickUserAsync(Project project,User user);
		public Task AddUserAsync(Project project,User user);


	}
}
