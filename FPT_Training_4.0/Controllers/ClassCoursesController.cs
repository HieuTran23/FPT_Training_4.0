using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPT_Training_4._0.Models;

namespace FPT_Training_4._0.Controllers
{
    public class ClassCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassCourses
        public ActionResult Index()
        {
            return View(db.ClassCourse.ToList());
        }

        // GET: ClassCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourse.Find(id);
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            return View(classCourse);
        }

        // GET: ClassCourses/Create
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Id", "Name");
            return View();
        }

        public ActionResult CreateWithTrainer(string trainer_id, string trainer_name)
        {
            ViewBag.trainer_id = trainer_id;
            ViewBag.trainer_name = trainer_name;
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Id", "Name");
            return View("Create");
        }

        // POST: ClassCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string classTrainerId,[Bind(Include = "Id,ClassName,Description,DateFrom,DateTo, CourseId")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                var trainer = db.Users.Find(classTrainerId);
                if (trainer != null)
                    classCourse.Trainer = trainer;
                db.ClassCourse.Add(classCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Id", "Name");
            return View(classCourse);
        }

        // GET: ClassCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourse.Find(id);
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            return View(classCourse);
        }

        // POST: ClassCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassName,Description,DateFrom,DateTo,CreateDate")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classCourse);
        }

        // GET: ClassCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourse.Find(id);
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            return View(classCourse);
        }

        // POST: ClassCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassCourse classCourse = db.ClassCourse.Find(id);
            db.ClassCourse.Remove(classCourse);
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
