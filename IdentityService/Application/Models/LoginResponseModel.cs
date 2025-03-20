namespace IdentityService.Application.Models
{
    public class LoginResponseModel
    {
        public required string Email { get; set; }
        public required string Token { get; set; }

    }
}
