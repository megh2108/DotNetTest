using DotNetTestWebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DotNetTestWebApi.Data.Contract
{
    public interface IAuthRepository
    {
        public bool RegisterUser(User user);

        public bool UserExists(string username, string email);

        public List<User> GetAllUsers();
        public User? ValidateUser(string username);
    }
}
