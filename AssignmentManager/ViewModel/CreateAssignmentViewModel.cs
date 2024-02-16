using AssignmentManager.Data.Enum;

namespace AssignmentManager.ViewModel
{
    public class CreateAssignmentViewModel
    {
        public string AppUserId { get; set; }

        public Priority Priority { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
