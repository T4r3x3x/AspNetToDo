using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Timers;

namespace Representation.Controllers
{
	//	[Route("/debug")]	
	public class DebugController : Controller
	{
		private readonly IUserRepository _userRepository;

		public DebugController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult Swagger()
		{
			return Redirect("/swagger");
		}


		[HttpGet("/getToken")]
		public IActionResult GetJwtToken(string email)
		{
			var user = _userRepository.GetUserByEmailAsync(email);
			if (user == null)
				return BadRequest();


			var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
			// создаем JWT-токен	
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					claims: claims,
					expires: DateTime.UtcNow.AddMinutes(60),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

			return Json(new JwtSecurityTokenHandler().WriteToken(jwt));
		}
	}
}
