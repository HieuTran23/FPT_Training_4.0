using FPT_Training_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Data.Entity;

namespace FPT_Training_4._0.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CourseType = new SelectList(db.courseTypes.ToList(), "TypeName", "TypeName") ;

            return View();
        }
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseType,Name,Description,DateBegin,DateEnd")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseType = new SelectList(db.courseTypes.ToList(), "TypeName", "TypeName");
            return View(course);

        }
        public ActionResult Edit(int? id)
        {
            ViewBag.CourseType = new SelectList(db.courseTypes.ToList(), "TypeName", "TypeName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseType,Name,Description,DateBegin,DateEnd")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseType = new SelectList(db.courseTypes.ToList(), "TypeName", "TypeName");
            return View(course);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
