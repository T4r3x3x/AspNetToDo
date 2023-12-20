using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using DAL.Entities;
using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
	//	private readonly Mapper _mapper;

		public UserService(IUserRepository userRepository)/*, Mapper mapper)*/
		{
			_userRepository = userRepository;
		//	_mapper = mapper;
		}

		public async Task<IResponse<bool>> TrySignIn(SignInModel signInModel)
		{
			//PasswordHasher<SignInModel> hasher = new PasswordHasher<SignInModel>();

			//var user = await _userRepository.GetUserByEmailAsync(signInModel.Email);

			//if (user != null)
			//{
			//	var hashedPassword = hasher.HashPassword(signInModel, signInModel.Password);
			//	var originHashedPassword = user.Password;

			//	if (hasher.VerifyHashedPassword(signInModel, hashedPassword, originHashedPassword) == PasswordVerificationResult.Success)
			//		return new BaseResponse<bool>("The password real", Enum.StatusCode.Success, true);


			//	return new BaseResponse<bool>("The password doesn't match!", Enum.StatusCode.WrongPassword, false);

			//}
			return new BaseResponse<bool>(String.Format("Can't find a user with this email {0}", signInModel.Email),
				Enum.StatusCode.CantFindUser, false);
		}

		public async Task<IResponse<bool>> TrySignUp(SignUpModel signUpModel)
		{
			var user = await _userRepository.GetUserByEmailAsync(signUpModel.Password);
			
			if (user != null)
			{
			//	user = _mapper.Map<User>(signUpModel);
			//	await _userRepository.CreateAsync(user);

				return new BaseResponse<bool>("A new user was registred!", Enum.StatusCode.Success, true);
			}
				

			return new BaseResponse<bool>("This email already registred!",Enum.StatusCode.EmailAlreadyRegistred,false);

		}
	}
}
