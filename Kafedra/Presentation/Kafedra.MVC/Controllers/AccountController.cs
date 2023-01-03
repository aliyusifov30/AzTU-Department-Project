using Kafedra.Application.ViewModel.Account;
using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Kafedra.Domain.Identities;
using Kafedra.Infrastructure.Services.EmailServices;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
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
        private readonly IOptions<MailSettings> _mailSettings;
        private readonly IWebHostEnvironment _env;
        //testing number 1-5 -3
        public AccountController(KafedraContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<MailSettings> mailSettings, IWebHostEnvironment env)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mailSettings = mailSettings;
            _env = env;
            //asjdnhfbsd xncvsdja  bbsdcb klahebckab ealhwal
            //salam qaqa netetr
            // deb7fcf7d04cf081f44000abc2e449549571606f
        }
        public ActionResult Login(int id)
        {
            return View();
        }
        public ActionResult SuccessRegistration()
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
                ModelState.AddModelError(string.Empty, "Email və ya şifrə yanlışdır");
               
                return View(login);
            }
           
            if (!user.IsActivated)
            {
                ModelState.AddModelError(string.Empty, "Zəhmət olmasa,hesabiniz aktivləşdirin.Email'nizi nəzərdən keçirin");
                return View(login);
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email və ya şifrə yanlışdır");
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
                Surname = register.Surname,
                Email = register.Email,
                FromAztu = register.FromAztu,
                UserName = register.UserName
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            var pathToFile = _env.WebRootPath
                           + Path.DirectorySeparatorChar.ToString()
                           + "Templates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "EmailTemplate"
                           + Path.DirectorySeparatorChar.ToString()
                           + "SendEmail.html";

            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }


            string confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { email = newUser.Email, token }, HttpContext.Request.Scheme, Request.Host.ToString());

            string messageBody = string.Format(builder.HtmlBody, confirmationLink, register.Email, register.UserName);


           Email.SendMail(register.Email, "Message", messageBody, _mailSettings.Value.Email, _mailSettings.Value.Password);

           
            await _userManager.AddToRoleAsync(newUser, UserRoles.Student.ToString());
            return RedirectToAction(nameof(SuccessRegistration));



            //   await _userManager.AddToRoleAsync(newUser, UserRoles.Member.ToString());



        }
      
        public async Task<ActionResult> ConfirmEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                user.IsActivated = true;
                await _context.SaveChangesAsync();
            }
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
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