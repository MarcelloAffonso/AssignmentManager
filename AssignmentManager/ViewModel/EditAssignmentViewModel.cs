using AssignmentManager.Data.Enum;
using AssignmentManager.Models;

namespace AssignmentManager.ViewModel
{
    public class EditAssignmentViewModel
    {
        public int AssignmentId { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
