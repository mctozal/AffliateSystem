using MeSoft.API.Services.Abstract;
using MeSoft.Core.EntityModels;
using MeSoft.Core.Models;
using MeSoft.Core.Repositories;
using MeSoft.Shared.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace MeSoft.API.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _userRepository;

        public IdentityService(IConfiguration configuration, IRepository<User> userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            // Validate user exists and password matches
            var user = (await _userRepository.GetAll(u => u.Email == requestModel.Email)).FirstOrDefault();
            

            if (user == null || !VerifyPassword(requestModel.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }


            // Generate token
            var token = GenerateJwtToken(user.Email, user.Role.ToString());
            return new LoginResponseModel
            {
                Email = user.Email,
                Token = token
            };
        }

        public async Task<RegisterResponseModel> Register(RegisterRequestModel requestModel)
        {
            // Check if user already exists
            var existingUser = await _userRepository.GetAll(u => u.Email == requestModel.Email);
            if (existingUser.Count > 1)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            // Hash the password
            var passwordHash = HashPassword(requestModel.Password);

            // Create new user
            var user = new User
            {
                Email = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                PasswordHash = passwordHash,
                Role = UserRole.Customer
            };

            await _userRepository.AddAsync(user);

            // Generate token
            var token = GenerateJwtToken(user.Email, user.Role.ToString());
            return new RegisterResponseModel
            {
                Email = user.Email,
                Token = token
            };
        }

        // Helper method to generate JWT
        private string GenerateJwtToken(string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role) // Use role instead of "Security"
            };

            var secret = _configuration["AuthConfig:Secret"];
            if (string.IsNullOrEmpty(secret))
            {
                throw new InvalidOperationException("JWT secret is not configured.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                signingCredentials: creds,
                notBefore: DateTime.Now
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Simple password hashing (replace with a stronger method like BCrypt in production)
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        // Simple password verification (replace with proper method in production)
        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash; // Use constant-time comparison in production
        }
    }
}