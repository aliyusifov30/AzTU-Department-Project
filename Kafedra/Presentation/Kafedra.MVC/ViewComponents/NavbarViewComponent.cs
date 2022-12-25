using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
