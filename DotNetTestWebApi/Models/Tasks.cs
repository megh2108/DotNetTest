using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetTestWebApi.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Priority { get; set; } // Values: "Low", "Medium", "High"

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // Values: "To Do", "In Progress", "Completed"

        public DateTime? DueDate { get; set; }

        [ForeignKey("AssignedUser")]
        public int? AssignedTo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }

        // Navigation properties
        public Project Project { get; set; }
        public User AssignedUser { get; set; }
        public User CreatedByUser { get; set; }
    }
}
