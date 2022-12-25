using Kafedra.Application.ViewModel.Account;
using Kafedra.Domain.Enums;
using Kafedra.Domain.Identities;
using Kafedra.Infrastructure.Services.EmailServices;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using static Kafedra.Domain.Identities.AppUser;

namespace Kafedra.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly KafedraContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;

        //testing number 1-5 -3
        public AccountController(KafedraContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

            //asjdnhfbsd xncvsdja  bbsdcb klahebckab ealhwal
            //salam qaqa netetr
// deb7fcf7d04cf081f44000abc2e449549571606f
        }
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user is null)
            {
                return NotFound();
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: AccountController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);

            AppUser newUser = new AppUser
            {
                Name = register.Name,
                Surname=register.Surname,
                Email = register.Email,
                FromAztu=register.FromAztu,
                UserName=register.UserName             
                       };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Json("Xeta");
            }
            await _userManager.AddToRoleAsync(newUser, UserRoles.Student.ToString());


            //   await _userManager.AddToRoleAsync(newUser, UserRoles.Member.ToString());

            return RedirectToAction(nameof(HomeController.Index), "Home");

        }
        public async Task<ActionResult> logOut(int id)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }

        // GET: AccountController/Edit/5

    }
}