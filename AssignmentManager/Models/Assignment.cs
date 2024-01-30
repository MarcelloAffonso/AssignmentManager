using AssignmentManager.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace AssignmentManager.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        public List<Note> Notes { get; set; }
    }
}
