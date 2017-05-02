using KevinsMVCLab;
using KevinsMVCLab.HelperClasses;
using KevinsMVCLab.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCLabb.Data.Repositories;
using MVCLabData.Repositories.Interfaces;
using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KevinsMVCLab.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private UserManager<IdentityUser> userManager;
        public AuthenticationController()
        {
            var context = new MyIdentityDBContext();
            var store = new UserStore<IdentityUser>(context);
            userManager = new UserManager<IdentityUser>(store);
        }
        // GET: Authentication
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string username,
            string password,
            string email)
        {
            //Setup new user
            var user = new IdentityUser
            {
                UserName = username,
                Email = email
            };
            //Register user in db
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                //Create a identity
                var identity = await userManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                //Create new claim            
                identity.AddClaim(new Claim("Email", user.Email));

                var authorisationManager =
                    HttpContext.GetOwinContext().Authentication;
                //Sign in
                authorisationManager.SignIn(identity);
              
            }
            return RedirectToAction("Index", "Gallery");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(
            string username,
            string password)
        {
            var user = await userManager.FindAsync(username, password);

            if (user == null) { return View(); }

            var identity = await userManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            var authorisationManager = HttpContext.GetOwinContext().Authentication;

            authorisationManager.SignIn(identity);

            return RedirectToAction("Index", "Gallery");
        }

        public ActionResult Logout()
        {

            var authorisationManager = HttpContext.GetOwinContext().Authentication;

            authorisationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }
    }
}