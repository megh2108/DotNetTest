using System.ComponentModel.DataAnnotations;

namespace DotNetTestWebApi.Dtos
{
    public class AddProjectDto
    {

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }
    }
}
