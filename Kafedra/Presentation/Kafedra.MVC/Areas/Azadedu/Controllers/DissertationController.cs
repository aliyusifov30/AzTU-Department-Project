using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.DissertationDTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class DissertationController : Controller
    {

        private readonly IDissertationRepository _dissertationRepository;
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IFileService _fileService;
        private string _errorMessage;
        private readonly IWebHostEnvironment _env;

        public DissertationController(IDissertationRepository dissertationRepository, IQualificationRepository qualificationRepository, IFileService fileService, IWebHostEnvironment env)
        {
            _dissertationRepository = dissertationRepository;
            _qualificationRepository = qualificationRepository;
            _fileService = fileService;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var items = _dissertationRepository.GetAll(x => x.IsDeleted == false);
            ViewBag.PageSize = 8;
            return View(PagenatedListDto<Dissertation>.Save(items, page, 8));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Qualification = _qualificationRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DissertationCreateDto dissertationCreateDto, string publicationYear , string defenseYear)
        {
            ViewBag.Qualification = _qualificationRepository.GetAll().Where(x => x.IsDeleted == false).ToList();

            bool checkFile = _fileService.CheckFile(dissertationCreateDto.File, 10485760, ref _errorMessage, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf");
           
            if (checkFile == false)
            {
                ModelState.AddModelError("File", _errorMessage);
                return View(dissertationCreateDto);
            }

            string fileName = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/dissertations/", dissertationCreateDto.File);

            DateTime publicationYearTime = Convert.ToDateTime(publicationYear);
            DateTime defenseYearTime = Convert.ToDateTime(defenseYear);

            Qualification qualification = await _qualificationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == dissertationCreateDto.QualificationId);

            await _dissertationRepository.Create(new()
            {
                Qualification = qualification,
                Author = dissertationCreateDto.Author,
                Name = dissertationCreateDto.Name,
                Manager = dissertationCreateDto.Manager,
                Description = dissertationCreateDto.Description,
                Point = dissertationCreateDto.Point,
                Topic = dissertationCreateDto.Topic,
                DissertationType = dissertationCreateDto.DissertationType,
                DefenseYear = defenseYearTime,
                PublicationYear = publicationYearTime,
                FilePath = fileName
            });

            await _dissertationRepository.Save();

            TempData["Success"] = "Created";

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _dissertationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.Qualification = _qualificationRepository.GetAll().Where(x => x.IsDeleted == false).ToList();

            string publicationYearTime = item.PublicationYear.ToString("dd/MM/yyyy").Replace("/", "-");
            string defenseYearTime = item.DefenseYear.ToString("dd/MM/yyyy").Replace("/","-");


            DissertationEditDto dissertationEditDto = new DissertationEditDto
            {
                Author = item.Author,
                Name = item.Name,
                Description = item.Name,
                DissertationType = item.DissertationType,
                Manager = item.Manager,
                Point = item.Point,
                Topic = item.Topic,
                FilePath = item.FilePath,
                Id = item.Id,
            };

            TempData["PublishYear"] = publicationYearTime;
            TempData["DefenseYear"] = defenseYearTime;

            return View(dissertationEditDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DissertationEditDto dissertationEditDto, string publicationYear, string defenseYear)
        {

            ViewBag.Qualification = _qualificationRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
            
            var oldDissertation = await _dissertationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == dissertationEditDto.Id);

            string fileName = null;

            if(dissertationEditDto.File != null)
            {
                bool checkFile = _fileService.CheckFile(dissertationEditDto.File, 10485760, ref _errorMessage, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf");

                if (checkFile == false)
                {
                    ModelState.AddModelError("File", _errorMessage);
                    return View(dissertationEditDto);
                }

                _fileService.DeleteAsync(_env.WebRootPath, "/uploads/dissertations/", oldDissertation.FilePath);
                fileName = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/dissertations/", dissertationEditDto.File);

            }else
            {
                fileName = oldDissertation.FilePath;
            }

            DateTime publicationYearTime = Convert.ToDateTime(publicationYear);
            DateTime defenseYearTime = Convert.ToDateTime(defenseYear);

            oldDissertation.PublicationYear = publicationYearTime;
            oldDissertation.DefenseYear = defenseYearTime;
            oldDissertation.Author = dissertationEditDto.Author;
            oldDissertation.Description = dissertationEditDto.Description;
            oldDissertation.Author = dissertationEditDto.Author;
            oldDissertation.Point = dissertationEditDto.Point;
            oldDissertation.Topic = dissertationEditDto.Topic;
            oldDissertation.Name = dissertationEditDto.Name;
            oldDissertation.DissertationType = dissertationEditDto.DissertationType;

            await _dissertationRepository.Save();

            TempData["Success"] = "Everything Is Ok";


            return RedirectToAction("index");
        }


        public async Task<IActionResult> UnActive(int id)
        {
            var item = await _dissertationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            _dissertationRepository.UnActive(item);
            await _dissertationRepository.Save();
            return RedirectToAction("index");
        }


    }
}
