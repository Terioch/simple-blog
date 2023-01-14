using SimpleBlog.Dtos;
using SimpleBlog.Models;
using SimpleBlog.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace SimpleBlog.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> NewUser(UserDto userDto)
        {
            (byte[] passwordSalt, byte[] passwordHash) = GeneratePasswordHash(userDto.Password);

            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _unitOfWork.Users.Add(user);

            await _unitOfWork.Complete();

            return user;
        }

        private (byte[], byte[]) GeneratePasswordHash(string password)
        {
            var hmac = new HMACSHA512();

            byte[] passwordSalt = hmac.Key;

            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (passwordSalt, passwordHash);
        }
    }
}
