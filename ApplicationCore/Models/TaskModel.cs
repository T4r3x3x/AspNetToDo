using System.ComponentModel.DataAnnotations;


namespace ApplicationCore.Models
{
	public class TaskModel
	{
		public long Id { get; set; }

		[Display(Name = "Название задачи")]
		public string Title { get; set; }

		[Display(Name = "Описание задачи")]
		public string? Description { get; set; }
		public string Created { get; set; }

		[Display(Name = "Приоритет задачи")]
		public string Priority { get; set; }
		public string Status { get; set; }
	}
}
