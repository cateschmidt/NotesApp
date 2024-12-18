using Microsoft.AspNetCore.Mvc;

namespace NotesApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
