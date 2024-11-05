using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Models;
using Microsoft.Extensions.Configuration;

namespace DotNetTestWebApi.Services.Contract
{
    public interface IAuthService
    {

        public ServiceResponse<string> RegisterUserService(RegisterDto register);

        public ServiceResponse<string> LoginUserService(LoginDto login);

        public ServiceResponse<List<UserDto>> GetAllUsers();
    }
}
