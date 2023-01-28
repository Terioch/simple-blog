using SimpleBlog.Dtos;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IAuthService
    {
        Task<ActionWrapper<AuthResult>> NewUser(UserDto userDto);

        ActionWrapper<AuthResult> AuthenticateUser(UserDto userDto);
    }
}
