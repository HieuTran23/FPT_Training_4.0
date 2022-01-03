using FPT_Training_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Training_4._0.Controllers
{
    [Authorize(Roles = "Admin,Training Staff")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        
        public ActionResult Index()
        {
            var accountNumber = db.Users.ToList().Count().ToString();
            var courseTypeNumber = db.courseTypes.ToList().Count().ToString();
            var courseNumber = db.Courses.ToList().Count().ToString();
            var classCourseNumber = db.ClassCourse.ToList().Count().ToString();
            ViewBag.accountNumber = accountNumber;
            ViewBag.courseTypeNumber = courseTypeNumber;
            ViewBag.courseNumber = courseNumber;
            ViewBag.classCourseNumber = classCourseNumber;
            return View();
        }
    }
}