using Microsoft.IdentityModel.Tokens;
using SimpleBlog.Dtos;
using SimpleBlog.Entities;
using SimpleBlog.Models;
using SimpleBlog.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SimpleBlog.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ActionWrapper<AuthResult>> NewUser(UserDto userDto)
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

            var result = GenerateAccessToken(user);

            return new ActionWrapper<AuthResult>().Success("Registration was successful", result);
        }

        private static (byte[], byte[]) GeneratePasswordHash(string password)
        {
            var hmac = new HMACSHA512();

            byte[] passwordSalt = hmac.Key;

            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (passwordSalt, passwordHash);
        }

        public ActionWrapper<AuthResult> AuthenticateUser(UserDto userDto)
        {
            var user = _unitOfWork.Users.GetAll(x => x.Email == userDto.Email).FirstOrDefault();

            if (user == null)
            {
                return new ActionWrapper<AuthResult>().Failed("User was not found", null);
            }

            if (!ValidatePasswordHash(user, userDto.Password))
            {
                return new ActionWrapper<AuthResult>().Failed("Login details are invalid", null);
            }

            var result = GenerateAccessToken(user);

            return new ActionWrapper<AuthResult>().Success("Login was successful", result);
        }

        private static bool ValidatePasswordHash(User user, string password)
        {
            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(user.PasswordHash);
        }

        private AuthResult GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var expires = DateTime.UtcNow.AddMinutes(10);

            var token = new JwtSecurityToken(null, null, claims, null, expires, credentials);

            return new AuthResult
            {
                UserDto = new UserDto 
                { 
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                },
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = expires
            };
        }
    }
}
