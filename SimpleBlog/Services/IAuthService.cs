using SimpleBlog.Dtos;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IAuthService
    {
        Task<User> NewUser(UserDto userDto);
    }
}
