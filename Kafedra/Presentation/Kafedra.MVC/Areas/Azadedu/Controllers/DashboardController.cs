using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Areas.Manage.Controllers
{
    [Area("Azadedu")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}