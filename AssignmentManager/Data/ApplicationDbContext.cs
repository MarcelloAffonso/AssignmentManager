using AssignmentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
    }
}