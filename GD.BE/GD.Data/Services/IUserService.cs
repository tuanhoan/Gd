using GD.Requests;
using GD.Responses;
using System.Threading.Tasks;

namespace GD.Data.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);

        Task<LogoutResponse> LogoutAsync(int userId);
        Task<UserResponse> GetInfoAsync(int userId);
    }
}
