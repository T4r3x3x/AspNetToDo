using AspNetMVCTest.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models;
using System.Diagnostics;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ApplicationCore.Filters.ToDo;
using DAL.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetMVCTest.Controllers
{
	[Route("/[controller]")]
	public class TaskController : Controller
	{
		private readonly ILogger<TaskController> _logger;
		private readonly ITaskService _toDoService;

		public TaskController(ILogger<TaskController> logger, ITaskService toDoService)
		{
			_logger = logger;
			_toDoService = toDoService;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create(CreateTaskModelView toDoModel)
		{
			if (ModelState.IsValid)
			{
				var response = await _toDoService.CreateAsync(toDoModel);

				if (response.StatusCode == ApplicationCore.Enum.StatusCode.Success)
					return View("Index");

				else
					return BadRequest(response.StatusCode);
			}

			return View("Index", toDoModel);
		}

		[HttpPost("SetStatus")]
		public async Task<IActionResult> SetStatus([BindRequired] int id, Status status)
		{
			var response = await _toDoService.SetStatusAsync(id, status);

			if (response.StatusCode == ApplicationCore.Enum.StatusCode.Success)
				return Ok();
			else
				return BadRequest(response.StatusCode);
		}


		[HttpDelete("Delete")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _toDoService.DeleteTaskAsync(id);

			if (response.StatusCode == ApplicationCore.Enum.StatusCode.Success)
				return Ok();
			else
				return BadRequest(response.StatusCode);
		}

		[HttpPost("Edit")]
		public async Task<IActionResult> Edit(CreateTaskModelView toDoModel)
		{
			throw new NotImplementedException();
		}

		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAllToDo(TaskFilter toDoFilter)
		{
			IResponse<IEnumerable<TaskModel>>? response = await _toDoService.GetAllTaskAsync(toDoFilter);
			return Json(new { data = response.Data });
		}


		[HttpGet("GetMinDate")]
		public async Task<IActionResult> GetMinDate()
		{
			var response = await _toDoService.GetMinDateAsync();

			return Ok(new { minDate = response.Data });
		}
	}
}