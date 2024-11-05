using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Services.Contract;
using DotNetTestWebApi.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;
        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult RegisterUser(RegisterDto registerDto)
        {

            var result = _userService.RegisterUserService(registerDto);

            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginDto login)
        {
            var response = _userService.LoginUserService(login);
            return !response.Success ? BadRequest(response) : Ok(response);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var response = _userService.GetAllUsers();
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
