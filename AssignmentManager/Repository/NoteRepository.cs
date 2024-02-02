using AssignmentManager.Data;
using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentManager.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool Add(Note note)
        {
            _context.Add(note);
            return Save();
        }

        public bool Delete(Note note)
        {
            _context.Remove(note);
            return Save();
        }

        public async Task<IEnumerable<Note>> GetNotesByAssignmentIdAsync(int assignmentId)
        {
            return await _context.Notes.Where(x => x.AssignmentId == assignmentId).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Note note)
        {
            _context.Update(note);
            return Save();
        }
    }
}
