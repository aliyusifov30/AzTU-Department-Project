using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.SubjectDTOs;
using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Repositories.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class SubjectController : Controller
    {

        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public IActionResult Index(int page = 1)
        {
            var subjetcs = _subjectRepository.GetAll();
            ViewBag.PageSize = 8;
            return View(PagenatedListDto<Subject>.Save(subjetcs, page, 8));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectCreateDto createDto)
        {

            if (!ModelState.IsValid)
            {
                return View(createDto);
            }
            await _subjectRepository.Create(new()
            {
                Name = createDto.Name
            });

            await _subjectRepository.Save();

            TempData["Success"] = "Created";
            
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _subjectRepository.GetAll().FirstOrDefaultAsync(x=>x.Id == id);
            SubjectEditDto subjectEditDto = new SubjectEditDto
            {
                Name = subject.Name,
                Id = subject.Id
            };

            return View(subjectEditDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubjectEditDto subjectEditDto)
        {
            var oldSubject = await _subjectRepository.GetAll().FirstOrDefaultAsync(x => x.Id == subjectEditDto.Id);
            oldSubject.Name = subjectEditDto.Name;

            TempData["Success"] = "Changed";


            await _subjectRepository.Save();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _subjectRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.IsDeleted = true;
            await _subjectRepository.Save();

            TempData["Success"] = "Deleted";

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Recover(int id)
        {
            var item = await _subjectRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.IsDeleted = false;
            await _subjectRepository.Save();

            TempData["Success"] = "Recover";

            return RedirectToAction("index");
        }






    }
}
