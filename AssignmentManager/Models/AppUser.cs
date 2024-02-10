using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AssignmentManager.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Assignment>? Assignments { get; set; }
    }
}
