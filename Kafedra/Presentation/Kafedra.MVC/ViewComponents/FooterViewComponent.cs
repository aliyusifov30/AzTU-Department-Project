using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
