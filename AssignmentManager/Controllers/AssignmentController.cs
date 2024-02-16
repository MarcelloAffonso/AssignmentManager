using AssignmentManager.Data;
using AssignmentManager.Data.Enum;
using AssignmentManager.Helper;
using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using AssignmentManager.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;

        private readonly UserManager<AppUser> _userManager;

        public AssignmentController(IAssignmentRepository assignmentRepository, UserManager<AppUser> userManager)
        {
            this._assignmentRepository = assignmentRepository;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Assignment> assignments = await _assignmentRepository.GetAssignmentsByUserIdAsync(userId);

            return View(assignments);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int assignmentId)
        {
            Assignment? assignment = await _assignmentRepository.GetAssignmentByIdAsync(assignmentId);

            if (assignment != null)
            {
                return View(assignment);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            CreateAssignmentViewModel createAssignmentVM = new CreateAssignmentViewModel()
            {
                AppUserId = userId
            };

            return View(createAssignmentVM);
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
                assignment.AppUserId = createAssignmentVM.AppUserId;
                assignment.LastUpdate = DateTime.Now;
                assignment.Notes = new List<Note>();

                _assignmentRepository.Add(assignment);
                return RedirectToAction("Index", "Dashboard");

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

            UpdateAssignmentViewModel editAssignmentVM = new UpdateAssignmentViewModel
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
        public async Task<IActionResult> Update(UpdateAssignmentViewModel updateAssignmentVM)
        {
            if (ModelState.IsValid)
            {
                Assignment assignment = AssignmentHelper.GetNewAssignment(updateAssignmentVM.Name, updateAssignmentVM.Description,
                    updateAssignmentVM.Priority, updateAssignmentVM.Status);

                // Default values for a created assignment
                assignment.AppUserId = "teste";
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
