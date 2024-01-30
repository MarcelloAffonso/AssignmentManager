using System.ComponentModel.DataAnnotations;

namespace AssignmentManager.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
