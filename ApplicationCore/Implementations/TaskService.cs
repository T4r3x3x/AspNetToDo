using ApplicationCore.Extensions;
using ApplicationCore.Filters.ToDo;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using DAL.Entities;
using DAL.Enum;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Implementations
{
	public class TaskService : ITaskService
	{
		private readonly IRepository<TaskEntity> _repository;
		private readonly ILogger<TaskService> _logger;

		public TaskService(IRepository<TaskEntity> toDoRepository, ILogger<TaskService> logger)
		{
			_repository = toDoRepository;
			_logger = logger;
		}

		public async Task<IResponse<CreateTaskModelView>> CreateAsync(CreateTaskModelView taskModel)
		{
			try
			{
				_logger.LogInformation("Attempt to create a new task entity at {0}", DateTime.Now);

				var task = await _repository.GetAll().Where(task => task.Created.Date == DateTime.Today).FirstOrDefaultAsync(toDo => toDo.Title == taskModel.Title);

				if (task != null)
					return new BaseResponse<CreateTaskModelView>("Task was already created", Enum.StatusCode.ToDoIsHasAlready, taskModel);


				task = new TaskEntity()
				{
					Title = taskModel.Title,
					Description = taskModel.Description,
					Priority = taskModel.Priority,
					Created = DateTime.Now,
				};

				await _repository.CreateAsync(task);

				_logger.LogInformation("Creation was successed at {0}", DateTime.Now);

				return new BaseResponse<CreateTaskModelView>(description: "ToDo was created successfully", Enum.StatusCode.Success, taskModel);
			}

			catch (Exception ex)
			{
				_logger.LogError("Creation was failred - {0}", ex);
				return new BaseResponse<CreateTaskModelView>(description: "Something went wrog with a server", Enum.StatusCode.ServerError, taskModel);
			}

		}

		public async Task<IResponse<bool>> DeleteTaskAsync(int id)
		{
			var toDo = await _repository.GetAsync(id);

			if (toDo == null)
				return new BaseResponse<bool>("The task wasn't found", Enum.StatusCode.ToDoNotFound, false);

			await _repository.DeleteAsync(toDo);
			return new BaseResponse<bool>("The task was deleted successefull", Enum.StatusCode.Success, true);
		}

		public async Task<IResponse<bool>> SetStatusAsync(int id, Status status)
		{
			var task = await _repository.GetAsync(id);

			if (task == null)
				return new BaseResponse<bool>("The task wasn't found", Enum.StatusCode.ToDoNotFound, false);

			task.Status = status;
			await _repository.UpdateAsync(task);

			return new BaseResponse<bool>("The task was completed", Enum.StatusCode.Success, true);
		}

		public async Task<IResponse<IEnumerable<TaskModel>>> GetAllTaskAsync(TaskFilter taskFilter)
		{
			try
			{
				var taskModelViews = await _repository.GetAll()

					.WhereIf(!string.IsNullOrWhiteSpace(taskFilter.Title), task => task.Title == taskFilter.Title)

					.WhereIf(taskFilter.Priority.HasValue, task => task.Priority == taskFilter.Priority)

					.Where(task => task.Created.Date == taskFilter.DateTime.Date)

					.Select(task => new TaskModel()
					{
						Id = task.Id,
						Title = task.Title,
						Description = task.Description,
						Priority = task.Priority.GetDisplayName(),
						Created = task.Created.ToShortDateString(),
						Status = task.Status.ToString(),
					})
					.ToListAsync();


				return new BaseResponse<IEnumerable<TaskModel>>("Ok", Enum.StatusCode.Success, taskModelViews);
			}
			catch (Exception ex)
			{
				_logger.LogError("Creation was failred - {0}", ex);
				return new BaseResponse<IEnumerable<TaskModel>>(description: "Something went wrog with a server", Enum.StatusCode.ServerError, null);
			}
		}

		public async Task<IResponse<String>> GetMinDateAsync()
		{
			var dateTimes = _repository.GetAll().Select(task => task.Created);
			DateTime minDate;
			
			if (dateTimes.Any())
				minDate = await dateTimes.MinAsync();
			else
				minDate = DateTime.Now;

			return new BaseResponse<String>("Date!", Enum.StatusCode.Success, minDate.ToStringHtml());

		}


	}
}