using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.Utilities;
using Kafedra.Application.ViewModel.Event;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class EventController : Controller
    {
        private string _errorMessage;
        private IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        private readonly IEventRepository _eventRepository;

        public EventController(IWebHostEnvironment env, IEventRepository eventRepository, IFileService fileService)
        {
            _env = env;
            _eventRepository = eventRepository;
            _fileService = fileService;
        }
 
        public async Task<IActionResult> Index(int page = 1)
        {
            var events = _eventRepository.GetAll(x=>x.IsDeleted==false);
            ViewBag.PageSize = 8;
            return View(PagenatedListDto<Event>.Save(events, page, 8));
        }
        public IActionResult Create()
        {

            DateTime startTime = DateTime.UtcNow.AddHours(4);

            TempData["StartYear"] = startTime.Year;
            TempData["StartMonth"] = startTime.Month;
            TempData["StartDay"] = startTime.Day;

            TempData["StartHour"] = startTime.Hour;
            TempData["StartMin"] = startTime.Minute;

            string s = TempData["StartYear"].ToString();

            return View();
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateDto createDto, string? time = null)
        {
            if (!ModelState.IsValid)
            {
                return View(createDto);
            }

            var arr = time.Split("-");
       
            DateTime startTime = Convert.ToDateTime(arr[0]);
            DateTime endTime = Convert.ToDateTime(arr[1]);

            bool checkImage = _fileService.CheckFile(createDto.ImageFile, 5000, ref _errorMessage, "image/jpeg", "image/png");

            if (checkImage == false)
            {
                ModelState.AddModelError("ImageFile", _errorMessage);
                return View(createDto);
            }

            string fileName = await _fileService.UploadAsync(_env.WebRootPath+"/uploads/events/", createDto.ImageFile);

            await _eventRepository.Create(new()
            {
                Content = createDto.Content,
                EndTime = endTime,
                StartTime = startTime,
                Image = fileName,
                Title = createDto.Title,
            });

            await _eventRepository.Save();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _eventRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            DateTime startTime = DateTime.UtcNow.AddHours(4);
            DateTime selectStartTime = Convert.ToDateTime(item.StartTime);
            DateTime selectEndTime = Convert.ToDateTime(item.EndTime);

            TempData["StartYear"] = startTime.Year;
            TempData["StartMonth"] = startTime.Month;
            TempData["StartDay"] = startTime.Day;

            TempData["StartHour"] = startTime.Hour;
            TempData["StartMin"] = startTime.Minute;


            #region selectStartTime

            TempData["SelectStartYear"] = selectStartTime.Year;
            TempData["SelectStartMonth"] = selectStartTime.Month;
            TempData["SelectStartDay"] = selectStartTime.Day;

            TempData["SelectStartHour"] = selectStartTime.Hour;
            TempData["SelectStartMin"] = selectStartTime.Minute;

            #endregion

            #region endTime

            TempData["SelectEndYear"] = selectEndTime.Year;
            TempData["SelectEndMonth"] = selectEndTime.Month;
            TempData["SelectEndDay"] = selectEndTime.Day;

            TempData["SelectEndHour"] = selectEndTime.Hour;
            TempData["SelectEndMin"] = selectEndTime.Minute;

            #endregion

            EventEditDto eventEditDto = new EventEditDto
            {
                Content = item.Content,
                Image = item.Image,
                Title = item.Title,
                Id = item.Id
            };

            return View(eventEditDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventEditDto eventEditDto, string? time = null)
        {
            var eventItem = await _eventRepository.GetAll().FirstOrDefaultAsync(x => x.Id == eventEditDto.Id);
            if (eventItem == null) return NotFound();
            string fileName = eventItem.Image;

            if (eventEditDto.ImageFile != null)
            {
                _fileService.DeleteAsync(_env.WebRootPath, "/uploads/events/", eventItem.Image);

                bool checkImage = _fileService.CheckFile(eventEditDto.ImageFile, 10485760, ref _errorMessage, "image/jpeg", "image/png");

                if (checkImage == false)
                {
                    ModelState.AddModelError("ImageFile", _errorMessage);
                    return View(eventEditDto);
                }

                fileName = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/events/", eventEditDto.ImageFile);
            }

            var arr = time.Split("-");

            DateTime startTime = Convert.ToDateTime(arr[0]);
            DateTime endTime = Convert.ToDateTime(arr[1]);

            eventItem.Content = eventEditDto.Content;
            eventItem.Title = eventEditDto.Title;
            eventItem.StartTime = startTime;
            eventItem.EndTime = endTime;
            eventItem.Image = fileName;

            await _eventRepository.Save();

            return RedirectToAction("index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var eventItem = await _eventRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
         
            if (eventItem == null)
            {
                return NotFound();
            }

            eventItem.IsDeleted = true;
            await _eventRepository.Save();

            return RedirectToAction("index");
        }

    }
}

