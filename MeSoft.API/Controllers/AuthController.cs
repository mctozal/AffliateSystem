
using MeSoft.API.Services.Abstract;
using MeSoft.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
        {
            try
            {
                var result = await _identityService.Login(loginRequestModel);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Unauthorized(ex.Message);
            }


        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel registerRequestModel)
        {
            var result = await _identityService.Register(registerRequestModel);
            return Ok(result);
        }
    }
}
