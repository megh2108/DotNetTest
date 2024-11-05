using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetTestWebApi.Data.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool RegisterUser(User user)
        {
            var result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username,PasswordSalt, PasswordHash, Email, UserRoleId, CreatedAt) VALUES (@Username,@PasswordSalt, @PasswordHash, @Email, @UserRoleId, @CreatedAt)", con);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@UserRoleId", user.UserRoleId);
                cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                result = rowsAffected > 0;
            }
            return result;
        }

        public bool UserExists(string username, string email)
        {
            bool exists = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Users WHERE LOWER(Username) = @Username OR LOWER(Email) = @Email", con);
                cmd.Parameters.AddWithValue("@Username", username.ToLower());
                cmd.Parameters.AddWithValue("@Email", email.ToLower());

                con.Open();
                exists = (int)cmd.ExecuteScalar() > 0;
                con.Close();
            }
            return exists;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                User user = new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString(),
                    Email = row["Email"].ToString(),
                    UserRoleId = Convert.ToInt32(row["UserRoleId"])
                };
                users.Add(user);
            }

            return users;
        }


        public User? ValidateUser(string username)
        {
            User? user = null;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE LOWER(Username) = @Username OR LOWER(Email) = @Username", con);
                cmd.Parameters.AddWithValue("@Username", username.ToLower());

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString(),
                            PasswordSalt = (byte[])reader["PasswordSalt"],
                            PasswordHash = (byte[])reader["PasswordHash"],
                            Email = reader["Email"].ToString(),
                            UserRoleId = Convert.ToInt32(reader["UserRoleId"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        };
                    }
                }
                con.Close();
            }
            return user;
        }
    }
}
