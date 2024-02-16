using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssignmentManager.ViewModel
{
    public class UpdateNoteViewModel
    {
        [Required]
        public int NoteId { get; set; }

        [Required]
        public int AssignmentId { get; set; }

        [Required (ErrorMessage = "You can't update a note without a description!")]
        public string Description { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
