using DAL.Enum;

namespace ApplicationCore.Filters.ToDo
{
	public class TaskFilter
	{
		public string? Title { get; set; }
		public Priority? Priority { get; set; }
		public DateTime DateTime { get; set; }
	}
}
