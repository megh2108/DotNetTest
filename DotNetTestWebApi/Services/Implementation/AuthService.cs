﻿using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Models;
using DotNetTestWebApi.Services.Contract;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Data.Implementation;

namespace DotNetTestWebApi.Services.Implementation
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;



        public AuthService(IAuthRepository userRepository, IConfiguration configuration)
        {
            _authRepository = userRepository;
            _configuration = configuration;

        }

        public ServiceResponse<string> RegisterUserService(RegisterDto register)
        {
            var response = new ServiceResponse<string>();
            var message = string.Empty;
            if (register != null)
            {
                message = CheckPasswordStrength(register.Password);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    response.Success = false;
                    response.Message = message;
                    return response;
                }
                else if (_authRepository.UserExists(register.Username, register.Email))
                {
                    response.Success = false;
                    response.Message = "User already exists";
                    return response;
                }
                else
                {
                    User user = new User()
                    {
                        Username = register.Username,
                        Email = register.Email,
                        UserRoleId = register.UserRoleId,
                    };

                    CreatePasswordHash(register.Password, out byte[] passwordHash, out byte[] passwordsalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordsalt;


                    var result = _authRepository.RegisterUser(user);

                    response.Success = result;
                    response.Message = result ? "User register successfully." : "Something went wrong. Please try after sometime.";
                }
            }
            return response;
        }

        public ServiceResponse<string> LoginUserService(LoginDto login)
        {
            var response = new ServiceResponse<string>();
            string message = string.Empty;
            if (login != null)
            {
                var user = _authRepository.ValidateUser(login.Username);
                if (user == null)
                {
                    response.Success = false;
                    response.Message = "Invalid user login id or password!";
                    return response;
                }

                else if (!VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
                {
                    response.Success = false;
                    response.Message = "Invalid user login id or password!";
                    return response;
                }
                string token = CreateToken(user);
                response.Message = "User login successfully.";
                response.Success = true;
                response.Data = token;
                return response;
            }
            response.Success = false;
            response.Message = "Something went wrong, Please try after sometime.";
            return response;
        }


        public ServiceResponse<List<UserDto>> GetAllUsers()
        {
            var response = new ServiceResponse<List<UserDto>>();
            var users = _authRepository.GetAllUsers();

            if (users.Any())
            {
                response.Data = users.Select(p => new UserDto
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Email = p.Email,
                    UserRoleId = p.UserRoleId,

                }).ToList();
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "No users found!";
            }

            return response;
        }

        private string CheckPasswordStrength(string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (password.Length < 8)
            {
                stringBuilder.Append("Mininum password length should be 8" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
            {
                stringBuilder.Append("Password should be alphanumeric" + Environment.NewLine);
            }
            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,*,(,),_,]"))
            {
                stringBuilder.Append("Password should contain special characters" + Environment.NewLine);
            }

            return stringBuilder.ToString();
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claimes = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Username.ToString()),
               new Claim("UserRoleId", user.UserRoleId.ToString()),
               new Claim("UserId", user.UserId.ToString()),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimes),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = signingCredentials

            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}