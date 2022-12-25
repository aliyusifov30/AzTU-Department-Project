using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;
using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class SettingController : Controller
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public SettingController(ISettingRepository settingReadRepository, IFileService fileService, IWebHostEnvironment env, ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
            _fileService = fileService;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var settings = _settingRepository.GetAll();
            ViewBag.PageSize = 8;
            return View(PagenatedListDto<Setting>.Save(settings, page, 8));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var setting = await _settingRepository.GetSingleAsync(x => x.Id == id);
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Setting setting)
        {
            //if (!ModelState.IsValid) return View(setting);

            var oldSetting = await _settingRepository.GetSingleAsync(x => x.Id == setting.Id);

            if (setting.ImageFile != null)
            {
                _fileService.DeleteAsync(_env.WebRootPath, "/uploads/settings/", oldSetting.Value);
                oldSetting.Value = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/settings/", setting.ImageFile);
            }
            else
            {
                oldSetting.Value = setting.Value;
            }

            await _settingRepository.Save();

            return RedirectToAction("index", "setting");
        }
    }
}
