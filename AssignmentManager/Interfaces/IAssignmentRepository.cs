using AssignmentManager.Models;

namespace AssignmentManager.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetAssignmentByIdAsync(int assignmentId);
        Task<IEnumerable<Assignment>> GetAssignmentsByUserIdAsync(string userId);
        bool Add(Assignment assignment);
        bool Update(Assignment assignment);
        bool Delete(Assignment assignment);
        bool Save();
    }
}
