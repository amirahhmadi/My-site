using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using My_site.Core.Services.UserService.Commands;
using My_site.Core.Services.UserService.Queries;
using My_site.Core.ViewModels.UserViewmodel;
using My_site.DataBase.Entities.Users;

namespace My_site.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserServiceCommand _Command;
        private readonly IUserServiceQuery _Query;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserController(IUserServiceCommand command, IUserServiceQuery query, IPasswordHasher<User> passwordHasher)
        {
            _Command = command;
            _Query = query;
            _passwordHasher = passwordHasher;
        }


        public IActionResult Index()
        {
            var user = _Query.GetUsers();
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existUser = await _Query.GetUserByPhone(model.Phone);
            if (existUser != null)
            {
                ModelState.AddModelError("", "این شماره تلفن قبلا استفاده شده!");
                return View(model);
            }

            var newUser = new User
            {
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password, // هش بعداً اعمال میشه
                CreationDate = DateTime.Now,
                Role = model.Role,
            };

            await _Command.CreateUserAsync(newUser);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, Route("Login"), AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
                return Redirect("/Admin"); // اگر قبلا لاگین کرده بود
            return View();
        }

        [HttpPost, Route("Login"),AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // گرفتن کاربر از دیتابیس
            var userEntity = await _Query.GetUserByPhone(model.Phone);

            if (userEntity == null)
            {
                ModelState.AddModelError("", "شماره یا رمز اشتباه است");
                return View(model);
            }

            // بررسی رمز هش‌شده
            var passwordCheck = _passwordHasher.VerifyHashedPassword(userEntity, userEntity.Password, model.Password);

            if (passwordCheck == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "شماره یا رمز اشتباه است");
                return View(model);
            }

            // ایجاد Claims برای Authentication
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                new Claim(ClaimTypes.Name, userEntity.Phone),
                new Claim(ClaimTypes.Role, userEntity.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

            return Redirect("/Admin");
        }

    }
}
