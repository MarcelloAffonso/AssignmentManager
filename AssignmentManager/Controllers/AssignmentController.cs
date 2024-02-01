using AssignmentManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            var x = new Assignment();
            x.AssignmentId = 1;
            x.Status = Data.Enum.Status.Open;
            x.Priority = Data.Enum.Priority.Trivial;
            x.Description = "Test assignment";
            x.LastUpdate = DateTime.Now;
            x.Name = "Test assignment";

            var notes = new List<Note>();

            notes.Add(new Note()
            {
                NoteId = 1,
                Description = "note 1"
            });

            notes.Add(new Note()
            {
                NoteId = 2,
                Description = "note 2"
            });

            x.Notes = notes;

            return View(x);
        }
    }
}
