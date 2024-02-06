using AssignmentManager.Data;
using AssignmentManager.Data.Enum;
using AssignmentManager.Helper;
using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using AssignmentManager.ViewModel;
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

        public async Task<IActionResult> Index()
        {
            IEnumerable<Assignment> assignments = await _assignmentRepository.GetAssignmentsByUserIdAsync(1);

            return View(assignments);
        }


        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int assignmentId)
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
        public async Task<IActionResult> Create(CreateAssignmentViewModel createAssignmentVM)
        {
            if (ModelState.IsValid)
            {
                // Mapping helper
                Assignment assignment = AssignmentHelper.GetNewAssignment(createAssignmentVM.Name, createAssignmentVM.Description,
                    createAssignmentVM.Priority, Status.Open);

                // Default values for a created assignment
                assignment.UserId = 1;
                assignment.LastUpdate = DateTime.Now;
                assignment.Notes = new List<Note>();

                _assignmentRepository.Add(assignment);
                return RedirectToAction("Index");

            }
            else
            {
                return View(createAssignmentVM);
            }
        }

        public async Task<IActionResult> Edit(int assignmentId)
        {
            Assignment? assignment = await _assignmentRepository.GetAssignmentByIdAsync(assignmentId);

            if (assignment == null)
            {
                return NotFound();
            }

            EditAssignmentViewModel editAssignmentVM = new EditAssignmentViewModel
            {
                AssignmentId = assignmentId,
                Description = assignment.Description,
                Priority = assignment.Priority,
                Status = assignment.Status,
                Name = assignment.Name
            };

            return View(editAssignmentVM);

        }

        [HttpPost]
        public async Task<IActionResult> Update(EditAssignmentViewModel updateAssignmentVM)
        {
            if (ModelState.IsValid)
            {
                Assignment assignment = AssignmentHelper.GetNewAssignment(updateAssignmentVM.Name, updateAssignmentVM.Description,
                    updateAssignmentVM.Priority, updateAssignmentVM.Status);

                // Default values for a created assignment
                assignment.UserId = 1;
                assignment.AssignmentId = updateAssignmentVM.AssignmentId;
                assignment.LastUpdate = DateTime.Now;
                assignment.Notes = assignment.Notes;

                _assignmentRepository.Update(assignment);
                return RedirectToAction("Index");

            }
            else
            {
                return View(updateAssignmentVM);
            }
        }
    }
}
