using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test_Project_IdentityMVC.Migrations;
using Test_Project_IdentityMVC.Models;

namespace Test_Project_IdentityMVC.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager _UserManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager)
        {
            UserManager = userManager;

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _UserManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _UserManager = value;
            }
        }
        // GET: User
        public ActionResult Index()
        {
            List<User> list = new List<User>();
            foreach (var U in UserManager.Users)
                list.Add(new User(U));
            return View(list);
        }
        public async Task<ActionResult> Details(string id)
        {
            var U = await UserManager.FindByIdAsync(id);
            return View(new User(U));
        }
        public async Task<ActionResult> Edit(User model)
        {
            var U = new ApplicationUser() { Id = model.Id, UserName = model.UserName };
            await UserManager.UpdateAsync(U);
            return RedirectToAction("Index");
        }
    }
}