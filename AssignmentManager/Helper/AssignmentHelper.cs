using AssignmentManager.Data.Enum;
using AssignmentManager.Models;

namespace AssignmentManager.Helper
{
    /// <summary>
    /// Helper class to generate all Assignment objects
    /// </summary>
    public static class AssignmentHelper
    {
        public static Assignment GetNewAssignment(string name, string description, Priority priority, Status status)
        {
            return new Assignment
            {
                Name = name,
                Description = description,
                Status = status,
                Priority = priority
            };
        }
    }
}
