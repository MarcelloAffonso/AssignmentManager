using AssignmentManager.Data;
using AssignmentManager.Interfaces;
using AssignmentManager.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentManager.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userAssignments = await _dashboardRepository.GetAllUserAssignments();

            DashboardViewModel dashboardVM = new DashboardViewModel()
            {
                Assignments = userAssignments
            };

            return View(dashboardVM);
        }
    }
}
