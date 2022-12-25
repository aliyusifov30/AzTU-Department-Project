using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.ViewModel.AnnouncementVM;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementRepository _announcementsRepository;
       
        public AnnouncementController( IAnnouncementRepository announcementsRepository)
        {
            _announcementsRepository = announcementsRepository;
        }
        // GET: EventController
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM()
            {
               
                Announcements = await _announcementsRepository.GetAll().ToListAsync(),
                
            };
            return View(model);
        }

        // GET: EventController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAnnouncementsVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                 await  _announcementsRepository.Create(new()
                    {
                        Content = vm.Content,
                        Title = vm.Title,
                       
                    });
                 await   _announcementsRepository.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(vm);
                }
               
            }
            catch
            {
                return Json("Error 404");
            }
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
             var x = await _announcementsRepository.GetByIdAsync(id);
                return View(x);
          
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateAnnouncementsVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Dbdata = await _announcementsRepository.GetByIdAsync(id);
                    if (Dbdata.Title == vm.Title && Dbdata.Content == vm.Content)
                    {

                    }
                    else
                    {
                        Dbdata.Title = vm.Title;
                        Dbdata.Content = vm.Content;
                        Dbdata.UpdatedAt = vm.CreatedorUpdate;
                        _announcementsRepository.Update(Dbdata);
                        await _announcementsRepository.Save();
                    }
                   
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(vm);
                }

            }
            catch
            {
                return Json("Error 404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActivOrUnactiv(int id)
        {
            try
            {
              var entity=  await _announcementsRepository.GetByIdAsync(id);
                 _announcementsRepository.UnActive(entity);
                await _announcementsRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json("Error 404");
            }
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
              await  _announcementsRepository.DeleteAsync(id);
                await _announcementsRepository.Save();
                return RedirectToAction("Announcement", "Index");
             

            }
            catch
            {
                return Json("Error 404");
            }
        }
    }
}
