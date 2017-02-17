using KevinsMVCLab.HelperClasses;
using KevinsMVCLab.ViewModels;
using MVCLabData.Repositories.Interfaces;
using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace KevinsMVCLab.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        private IUserRepository repo;

        public AuthenticationController(IUserRepository repo)
        {
            this.repo = repo;
        }
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            User userToLogin = null;

            userToLogin = repo.LoginUser(model.Email, model.Password);

            if (userToLogin != null)
            {

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, (userToLogin.FirstName + " " + userToLogin.LastName)),
                    new Claim(ClaimTypes.Email, userToLogin.Email),
                    new Claim(ClaimTypes.Sid, userToLogin.id.ToString()),
                    new Claim(ClaimTypes.Role, UserIsAdmin(userToLogin) ? "Admin" : "User")

                },
                        "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;



                authManager.SignIn(identity);

                return Content("/Home/Index");

            }
            ModelState.AddModelError("", "Invalid Email or Password");
            return Content("Invalid Email or Password");
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserViewModel user)
        {
            user.id = Guid.NewGuid();

            if (ModelState.IsValid && !repo.isEmailTaken(user.Email))
            {


                var newUser = ModelMapper.ModelToEntity(user);

                repo.AddOrUpdate(newUser);

                if (Request.IsAjaxRequest())
                {
                    return Content("Login");
                }
                return Redirect("/Auth/Login");
            }




            ModelState.AddModelError("", "Something went wrong");

            if (Request.IsAjaxRequest())
            {
                return Content("Invalid information!");
            }
            return View(user);
        }


        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }
        private bool UserIsAdmin(User user)
        {

            if (user.id == Guid.Parse("{3027308A-5C93-4694-869A-BA40F042F94C}"))
            {
                return true;
            }

            return false;

        }
    }
}