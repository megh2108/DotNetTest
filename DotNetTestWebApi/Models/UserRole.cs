using System.ComponentModel.DataAnnotations;

namespace DotNetTestWebApi.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
