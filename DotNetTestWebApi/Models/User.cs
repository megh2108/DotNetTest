using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetTestWebApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        [ForeignKey("UserRole")]
        public int UserRoleId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation 
        public UserRole UserRole { get; set; }

    }
}
