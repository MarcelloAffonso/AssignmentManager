using Microsoft.AspNetCore.Mvc;

namespace AssignmentManager.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
