using SimpleBlog.Dtos;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IAuthService
    {
        Task<ActionWrapper<UserDto>> NewUser(UserDto userDto);

        ActionWrapper<UserDto> AuthenticateUser(UserDto userDto);
    }
}
