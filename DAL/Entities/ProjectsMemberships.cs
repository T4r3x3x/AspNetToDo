using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class ProjectsMemberships
	{
		public long Id { get; set; }
		public Project Project { get; set; }
		public User Person { get; set; } 
		public Role Role { get; set; }		

	}
}
