using IisRest.Contracts.Dtos.Auth;

namespace IisRest.Contracts.Services
{
    public interface IAuthService
    {
        Task<BasicRegisterResponse> RegisterAsync(BasicRegisterRequest user);
        Task<BasicLoginResponse> LogInAsync(BasicLoginRequest user);
    }
}
