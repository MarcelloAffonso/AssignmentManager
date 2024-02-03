using System.ComponentModel.DataAnnotations;

namespace AssignmentManager.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        public virtual ICollection<Assignment>? Assignments { get; set; }
    }
}
