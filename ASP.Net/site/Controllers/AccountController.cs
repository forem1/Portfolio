using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Site.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationContext db;
        public string userEmail;

        public AccountController(ApplicationContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Auth(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.SingleOrDefault(x => x.Email == user.Email) == null) {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    userEmail = user.Email;
                    await Authenticate(user.Email); // аутентификация
                    Response.Redirect("HalfCheck");
                    System.Diagnostics.Debug.WriteLine("Зарегались");
                }
                else if (db.Users.SingleOrDefault(x => x.Email == user.Email).Password == user.Password) {
                    userEmail = user.Email;
                    await Authenticate(user.Email); // аутентификация
                    Response.Redirect("HalfCheck");
                    System.Diagnostics.Debug.WriteLine("Авторизовались");
                }
                System.Diagnostics.Debug.WriteLine("Не вошли");
                System.Diagnostics.Debug.WriteLine(userEmail);
                return View(user);
            }
            else
            {
                return View(user);
            }
        }

        [Authorize]
        public IActionResult HalfCheck()
        {
            return Content(User.Identity.Name);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Auth", "Account");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
