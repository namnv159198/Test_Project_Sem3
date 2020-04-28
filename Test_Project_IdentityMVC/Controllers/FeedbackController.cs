using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test_Project_IdentityMVC.Models;

namespace Test_Project_IdentityMVC.Controllers
{
    public class FeedbackController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Feedback
        public ActionResult Index()
        {
            var feedback = db.Feedbacks.ToList();
            return View(feedback);
        }
        public ActionResult Create()
        {
            FeedbackViewModel model = new FeedbackViewModel();
            model.Answers = Common.GetAnswers();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(FeedbackViewModel model)
        { 
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(new Feedback() { Answer = model.Select, Comment = model.Comment, Email = model.Email, Fullname = model.Fullname});
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}