using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
