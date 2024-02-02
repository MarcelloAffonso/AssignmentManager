﻿using AssignmentManager.Models;

namespace AssignmentManager.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesByAssignmentIdAsync(int assignmentId);
        bool Add(Note note);
        bool Update(Note note);
        bool Delete(Note note);
        bool Save();
    }
}
