using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.ViewModel.Home;
using Kafedra.MVC.Models;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kafedra.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISliderRepository _sliderRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IAnnouncementRepository _announcementsRepository;
        private readonly IPartnerRepository _partnerRepository;


        public HomeController(KafedraContext context, ISliderRepository sliderRepository, IEventRepository eventRepository, IAnnouncementRepository announcementsRepository, IPartnerRepository partnerRepository)
        {

            _sliderRepository = sliderRepository;
            _eventRepository = eventRepository;
            _announcementsRepository = announcementsRepository;
            _partnerRepository = partnerRepository;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM()
            {

                Sliders = await _sliderRepository.GetWhere(i=>!i.IsDeleted),
                Events = await _eventRepository.GetAll().Where(i=>i.IsDeleted==false).OrderByDescending(x=>x.Id).Take(5).ToListAsync(),
        
                Announcements = await _announcementsRepository.GetAll().Where(a => a.IsDeleted == false).ToListAsync(),
                Partners = await  _partnerRepository.GetAll().ToListAsync(),


            };
            return View(model);
        }
        

    }
}