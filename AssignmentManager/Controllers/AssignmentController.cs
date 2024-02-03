using AssignmentManager.Data;
using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            this._assignmentRepository = assignmentRepository;
        }

        public async Task<IActionResult> Index(int userId)
        {
            // var assignments = _context.Assignments.ToList();

            //var x = new Assignment();
            //x.AssignmentId = 1;
            //x.Status = Data.Enum.Status.Open;
            //x.Priority = Data.Enum.Priority.Trivial;
            //x.Description = "Test assignment";
            //x.LastUpdate = DateTime.Now;
            //x.Name = "Test assignment";

            //var notes = new List<Note>();

            //notes.Add(new Note()
            //{
            //    NoteId = 1,
            //    Description = "note 1"
            //});

            //var y = new Assignment();
            //y.AssignmentId = 2;
            //y.Status = Data.Enum.Status.Open;
            //y.Priority = Data.Enum.Priority.Urgent;
            //y.Description = "Test assignment Urgent";
            //y.LastUpdate = DateTime.Now;
            //y.Name = "URGENT!!";

            //y.Notes = notes;

            //var assignments = new List<Assignment>() { x, y }.OrderByDescending(a => a.Priority);

            IEnumerable<Assignment> assignments = await _assignmentRepository.GetAssignmentsByUserIdAsync(1);

            return View(assignments);
        }

        public async Task<IActionResult> Detail(int assignmentId)
        {
            Assignment? assignment = await _assignmentRepository.GetAssignmentByIdAsync(assignmentId);

            if (assignment != null)
            {
                return View(assignment);
            }

            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            assignment.Status = Data.Enum.Status.Open;
            assignment.LastUpdate = DateTime.Now;
            assignment.AssignmentId = 1;
            assignment.UserId = 1;
            assignment.Notes = new List<Note>();

            if(!ModelState.IsValid)
            {
                return View(assignment);
            }

            _assignmentRepository.Add(assignment);
            return RedirectToAction("Index");
        }
    }
}
