using IisRest.Contracts.Dtos.Auth;
using IisRest.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace IisRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService authService)
        {
            _service = authService;
        }

        [HttpPost("BasicRegistration")]
        public async Task<ActionResult<BasicRegisterResponse>> BasicRegistration(BasicRegisterRequest userData)
        {
            return await _service.RegisterAsync(userData);
        }

        [HttpPost("BasicLogin")]
        public async Task<ActionResult<BasicLoginResponse>> BasicLogIn(BasicLoginRequest userData)
        {
            return await _service.LogInAsync(userData);
        }
    }
}
