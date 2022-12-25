using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.Utilities.File;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Application.ViewModel.SliderVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class SliderController : Controller
    {
        private string _errorMessage;
        private IWebHostEnvironment _env;
        private readonly ISliderRepository _sliderRepository;
        public SliderController(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _sliderRepository = sliderRepository;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM()
            {

                Sliders = await _sliderRepository.GetAll().ToListAsync(),

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActivOrUnactiv(int id)
        {
            try
            {
                var entity = await _sliderRepository.GetByIdAsync(id);
                _sliderRepository.UnActive(entity);
                await _sliderRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json("Error 404");
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderVM sliderVM)
        {
            if (!ModelState.IsValid) return View(sliderVM);
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(sliderVM);
            if (!CheckImageValid(sliderVM))
            {
                ModelState.AddModelError("Photo", _errorMessage);
                return View(sliderVM);
            }
            string fileName = await sliderVM.Photo.SaveFile(_env.WebRootPath, "assets", "img");
            await _sliderRepository.Create(new()
            {
                Image = fileName,
            });

            await _sliderRepository.Save();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _sliderRepository.DeleteAsync(id);
                await _sliderRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json("Error 404");
            }
        }









        private bool CheckImageValid(CreateSliderVM eventVM)
        {

            if (!eventVM.Photo.CheckFileType("image/"))
            {
                _errorMessage = $"{eventVM.Photo.FileName}-faylin novu Ferqlidir!";
                return false;
            }
            if (!eventVM.Photo.CheckFileSize(50))
            {
                _errorMessage = $"{eventVM.Photo.FileName}- faylin olcusu boyukdur!";
                return false;
            }

            return true;
        }
    }
}
