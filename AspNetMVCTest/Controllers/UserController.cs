using ApplicationCore.Implementations;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Representation.Models.UserModels;

namespace Representation.Controllers
{
	[Route("[controller]")]
    public class UserController : Controller
	{
		private readonly UserService _userService;
		private readonly Mapper _mapper;

		public UserController(UserService userService, Mapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpPost("SignIn")]
		public async Task<IActionResult> SignIn(SignInModel signInModel)
		{
			if (ModelState.IsValid)
			{
				var response = await _userService.TrySignIn(signInModel);
				if (response.Data == true)
					return RedirectToAction("Index");

				return BadRequest(response.Description);
			}
			return View(signInModel);
		}


		[HttpPost("SignUp")]
		public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
		{
			if (ModelState.IsValid)
			{
				var signUpModel = _mapper.Map<SignUpModel>(signUpViewModel);
				var response = await _userService.TrySignUp(signUpModel);
				
				if(response.Data == true)
					 return RedirectToAction("Index");
				return BadRequest(response.Description);
			}
			return View(signUpViewModel);
		}
	}
}
