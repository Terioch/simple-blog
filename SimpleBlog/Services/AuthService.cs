using SimpleBlog.Dtos;
using SimpleBlog.Entities;
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

        public async Task<ActionWrapper<UserDto>> NewUser(UserDto userDto)
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

            return new ActionWrapper<UserDto>().Success("Registration was successful", userDto);
        }

        private static (byte[], byte[]) GeneratePasswordHash(string password)
        {
            var hmac = new HMACSHA512();

            byte[] passwordSalt = hmac.Key;

            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (passwordSalt, passwordHash);
        }

        public ActionWrapper<UserDto> AuthenticateUser(UserDto userDto)
        {
            var user = _unitOfWork.Users.GetAll(x => x.Email == userDto.Email).FirstOrDefault();

            if (user == null)
            {
                return new ActionWrapper<UserDto>().Failed("User was not found", userDto);
            }

            if (!ValidatePasswordHash(user, userDto.Password))
            {
                return new ActionWrapper<UserDto>().Failed("Login details are invalid", userDto);
            }

            return new ActionWrapper<UserDto>().Success("Login was successful", userDto);
        }

        private static bool ValidatePasswordHash(User user, string password)
        {
            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
}
