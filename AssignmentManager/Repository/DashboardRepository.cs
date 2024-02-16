using AssignmentManager.Data;
using AssignmentManager.Interfaces;
using AssignmentManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssignmentManager.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Assignment>> GetAllUserAssignments()
        {
            var currentUser = _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUser == null)
            {
                return new List<Assignment>();
            }

            var userAsssignments = _context.Assignments.Where(x => x.AppUserId == currentUser.ToString());

            return await userAsssignments.ToListAsync();
        }
    }
}
