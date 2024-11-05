using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetTestWebApi.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }

        // Navigation properties
        public User CreatedByUser { get; set; }

        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
