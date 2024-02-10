using AssignmentManager.Data;
using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentManager.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool Add(Assignment assignment)
        {
            _context.Add(assignment);
            return Save();
        }

        public bool Delete(Assignment assignment)
        {
            _context.Remove(assignment);
            return Save();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int assignmentId)
        {
            return await _context.Assignments.Include(a => a.Notes).FirstOrDefaultAsync(x => x.AssignmentId == assignmentId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByUserIdAsync(string userId)
        {
            return await _context.Assignments.Include(a => a.Notes).Where(x => x.AppUserId == userId).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public bool Update(Assignment assignment)
        {
            _context.Update(assignment);
            return Save();
        }
    }
}
