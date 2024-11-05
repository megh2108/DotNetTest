using System.ComponentModel.DataAnnotations;

namespace DotNetTestWebApi.Dtos
{
    public class UpdateTaskDto
    {
        public int TaskId { get; set; }

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

        public int? AssignedTo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }
    }
}
