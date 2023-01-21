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
            var result = await _authService.NewUser(userDto);
            return Ok(result);            
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto userDto)
        {
            var result = _authService.AuthenticateUser(userDto);
            return Ok(result);
        }
    }
}
