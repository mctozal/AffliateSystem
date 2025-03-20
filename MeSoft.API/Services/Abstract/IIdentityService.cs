
using MeSoft.Core.Models;

namespace MeSoft.API.Services.Abstract
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);

        Task<RegisterResponseModel> Register(RegisterRequestModel requestModel);
    }
}
