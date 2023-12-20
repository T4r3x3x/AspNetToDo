using System.ComponentModel.DataAnnotations;

namespace Representation.Models.ProjectModels
{
	public class ProjectCreateViewModel
	{
		[Required]
		public string Name { get; set; }

		public string Description { get; set; }


	}
}
