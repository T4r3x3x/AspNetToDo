using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
	{
		public Task<IResponse<bool>> TrySignIn(SignInModel signInModel);
		public Task<IResponse<bool>> TrySignUp(SignUpModel signUpModel);

	}
}
