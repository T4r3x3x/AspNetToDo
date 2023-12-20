using ApplicationCore.Filters.ToDo;
using ApplicationCore.Models;
using DAL.Enum;

namespace ApplicationCore.Interfaces
{
    public interface ITaskService
    {
        Task<IResponse<CreateTaskModelView>> CreateAsync(CreateTaskModelView taskModel);
		Task<IResponse<IEnumerable<TaskModel>>> GetAllTaskAsync(TaskFilter taskFilter);
        Task<IResponse<bool>> SetStatusAsync(int id, Status status);
        Task<IResponse<String>> GetMinDateAsync();
        Task<IResponse<bool>> DeleteTaskAsync(int id);
	}
}
