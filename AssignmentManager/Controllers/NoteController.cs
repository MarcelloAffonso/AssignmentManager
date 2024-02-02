using AssignmentManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentManager.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IActionResult> Index(int assignmentId)
        {
            var notes = await _noteRepository.GetNotesByAssignmentIdAsync(assignmentId);

            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
