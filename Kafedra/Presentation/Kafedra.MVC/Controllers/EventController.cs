using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.ViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IActionResult> AllEvents()
        {
            HomeVM home = new HomeVM()
            {
                Events = await _eventRepository.GetAll().OrderByDescending(x => x.Id).ToListAsync(),
            };
            return View(home);
        }
        public async Task<IActionResult> Detail(int id)
        {
            HomeVM home = new HomeVM()
            {
                Event = await _eventRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync(),
            };
            return View(home);
        }
    }
}
