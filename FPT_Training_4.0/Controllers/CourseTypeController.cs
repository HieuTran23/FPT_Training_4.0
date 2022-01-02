using FPT_Training_4._0.Extensions;
using FPT_Training_4._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FPT_Training_4._0.Controllers
{
    public class CourseTypeController : Controller
    {
        // GET: CourseType
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CourseType
        public ActionResult Index()
        {
            return View(db.courseTypes.ToList());
        }

        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeName,Description,CreateDate")] CourseType course)
        {
            if (ModelState.IsValid)
            {
                db.courseTypes.Add(course);
                db.SaveChanges();
                this.AddNotification("Create success", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("Create Fail", NotificationType.ERROR);
            return View(course);

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseType course = db.courseTypes.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeName,Description,CreateDate")] CourseType course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification("Edit Success", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("Edit Fail", NotificationType.ERROR);
            return View(course);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseType course = db.courseTypes.Find(id);
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
            CourseType course = db.courseTypes.Find(id);
            db.courseTypes.Remove(course);
            db.SaveChanges();
            this.AddNotification("Delete Success", NotificationType.SUCCESS);
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