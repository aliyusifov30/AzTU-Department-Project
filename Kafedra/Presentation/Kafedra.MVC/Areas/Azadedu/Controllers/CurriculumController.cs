using Kafedra.Application.DTOs.SubjectDTOs;
using Kafedra.Application.DTOs;
using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kafedra.Application.DTOs.CurriculumDTOs;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class CurriculumController : Controller
    {
        private readonly ICurriculumRepository _curriculumRepository;

        public CurriculumController(ICurriculumRepository curriculumRepository)
        {
            _curriculumRepository = curriculumRepository;
        }

        public IActionResult Index(int page = 1)
        {
            var items = _curriculumRepository.GetAll();
            ViewBag.PageSize = 8;
            return View(PagenatedListDto<Curriculum>.Save(items, page, 8));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CurriculumCreateDto curriculumCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return View(curriculumCreateDto);
            }
            await _curriculumRepository.Create(new()
            {
                Name = curriculumCreateDto.Name
            });

            await _curriculumRepository.Save();

            TempData["Success"] = "Created";

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _curriculumRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            CurriculumEditDto subjectEditDto = new CurriculumEditDto
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
            var oldSubject = await _curriculumRepository.GetAll().FirstOrDefaultAsync(x => x.Id == subjectEditDto.Id);
            oldSubject.Name = subjectEditDto.Name;

            TempData["Success"] = "Changed";


            await _curriculumRepository.Save();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _curriculumRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.IsDeleted = true;
            await _curriculumRepository.Save();

            TempData["Success"] = "Deleted";

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Recover(int id)
        {
            var item = await _curriculumRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.IsDeleted = false;
            await _curriculumRepository.Save();

            TempData["Success"] = "Recover";

            return RedirectToAction("index");
        }




    }
}
