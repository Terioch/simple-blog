using SimpleBlog.Dtos;

namespace SimpleBlog.Models
{
    public class AuthResult
    {
        public UserDto UserDto { get; set; }

        public string AccessToken { get; set; }

        public DateTime Expires { get; set; }
    }
}
