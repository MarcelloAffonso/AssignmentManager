using AssignmentManager.Models;

namespace AssignmentManager.Interfaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<Assignment>> GetAllUserAssignments();
    }
}
