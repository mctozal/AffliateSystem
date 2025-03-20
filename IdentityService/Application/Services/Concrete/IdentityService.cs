using IdentityService.Application.Models;
using IdentityService.Application.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Application.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        // test key, take it from azure key vault secret manager to use
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public IdentityService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;

        }

        public Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            var claims = new Claim[]
            {
              new Claim(ClaimTypes.Email,requestModel.Email),
              new Claim(ClaimTypes.Email,"Security")};

            var secret = _configuration["AuthConfig:Secret"];
            // take the key from azure key vault
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims, expires: expiry, signingCredentials: creds, notBefore: DateTime.Now);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponseModel response = new LoginResponseModel()
            {
                Email = requestModel.Email,
                Token = encodedJwt,
            };

            return Task.FromResult(response);
        }

        //register method
        public Task<RegisterResponseModel> Register(RegisterRequestModel requestModel)
        {
            // register 


            
            return Task.FromResult(response);
        }
    }
}
