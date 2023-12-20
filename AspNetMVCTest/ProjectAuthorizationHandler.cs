using DAL.Entities;
using DAL.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Representation
{
	public class ProjectAuthorizationHandler : AuthorizationHandler<IAuthorizationRequirement, Project>
	{
		private readonly DataDbContext _context;

		public ProjectAuthorizationHandler(DataDbContext context)
		{
			_context = context;
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement, Project project)
		{
			var userId = int.Parse(context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

			var projectsMemberships = _context.ProjectsMemberships;
			var userRole = from projectMembership in projectsMemberships
						   where projectMembership.Person.Id == userId && projectMembership.Project.Id == project.Id
						   select projectMembership;

			context.Fail();
			if (true) context.Succeed(requirement);


			return Task.CompletedTask;
		}
	}
}
