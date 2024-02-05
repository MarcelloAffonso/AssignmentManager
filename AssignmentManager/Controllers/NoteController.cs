using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using AssignmentManager.Repository;
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

        [HttpGet]
        public IActionResult Create(int assignmentId)
        {
            ViewBag.AssignmentId = assignmentId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }

            _noteRepository.Add(note);
            return RedirectToAction("Index", "Assignment");
        }

        public async Task<IActionResult> NotesPartial(int assignmentId)
        {
            var notes = await _noteRepository.GetNotesByAssignmentIdAsync(assignmentId);

            return PartialView("_NotesList", notes);
        }

    }
}
