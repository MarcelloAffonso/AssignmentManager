using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using AssignmentManager.Repository;
using AssignmentManager.ViewModel;
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
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int noteId)
        {
            var note = await _noteRepository.GetNotebyIdAsync(noteId);

            if (note != null)
            {
                UpdateNoteViewModel updateNotevm = new UpdateNoteViewModel()
                {
                    NoteId = noteId,
                    AssignmentId = note.AssignmentId,
                    Description = note.Description,
                    ErrorMessage = string.Empty
                };

                return View(updateNotevm);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Update(UpdateNoteViewModel updateNoteVM)
        {
            if (!ModelState.IsValid)
            {
                return View(updateNoteVM);
            }

            Note note = new Note()
            {
                Description = updateNoteVM.Description,
                AssignmentId = updateNoteVM.AssignmentId,
                NoteId = updateNoteVM.NoteId
            };

            _noteRepository.Update(note);
            return RedirectToAction("Index", "Assignment");
        }


        public async Task<IActionResult> NotesPartial(int assignmentId)
        {
            var notes = await _noteRepository.GetNotesByAssignmentIdAsync(assignmentId);

            return PartialView("_NotesList", notes);
        }

    }
}
