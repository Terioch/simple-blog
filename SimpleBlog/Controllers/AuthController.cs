using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Dtos;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            await _authService.NewUser(userDto);

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
