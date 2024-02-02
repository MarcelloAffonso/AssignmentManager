using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentManager.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
