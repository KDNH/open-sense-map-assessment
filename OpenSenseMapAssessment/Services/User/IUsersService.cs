using OpenSenseMapAssessment.Models.User;

namespace OpenSenseMapAssessment.Services.User
{
    public interface IUsersService
    {
        Task<UserRegisterResponse> RegisterUserAsync(UserRegisterRequest request);
        Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
        Task<bool> LogoutUserAsync();

    }
}
