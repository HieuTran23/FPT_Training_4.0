using FPT_Training_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Training_4._0.Controllers
{
    [Authorize(Roles = "Admin,Training Staff")]
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ApplicationUser
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult GetTrainer()
        {
            return PartialView("_TrainerSelectPartial", db.Users.ToList());
        }
        public ActionResult SelectTrainer()
        {

            return View(db.Users.ToList());
        }
    }
}