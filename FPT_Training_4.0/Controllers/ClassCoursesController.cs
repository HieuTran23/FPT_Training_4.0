using FPT_Training_4._0.Extensions;
using FPT_Training_4._0.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
        [Authorize(Roles = "Admin,Training Staff")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourse.Find(id);
            string query = "Select dbo.AspNetUsers.FullName from dbo.AspNetUsers,dbo.ClassCourses where (dbo.AspNetUsers.Id = dbo.ClassCourses.Trainer_Id) AND (dbo.ClassCourses.Id = " + id.Value + ")";
            var queryResult = db.Database.SqlQuery<string>(query);
            string name = queryResult.FirstOrDefault();
            if (name == null) name = "Not Assigned";
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.trainer_name = name;
            return View(classCourse);
        }

        // For user
        public ActionResult ClassDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourse.Find(id);
            string query = "Select dbo.AspNetUsers.FullName from dbo.AspNetUsers,dbo.ClassCourses where (dbo.AspNetUsers.Id = dbo.ClassCourses.Trainer_Id) AND (dbo.ClassCourses.Id = " + id.Value + ")";
            var queryResult = db.Database.SqlQuery<string>(query);
            string name = queryResult.FirstOrDefault();
            if (name == null) name = "Not Assigned";
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.trainer_name = name;
            return View(classCourse);
        }

        // GET: ClassCourses/Create
        [Authorize(Roles = "Admin,Training Staff")]
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Name", "Name");
            return View();
        }

        [Authorize(Roles = "Admin,Training Staff")]
        public ActionResult CreateWithTrainer(string trainer_id, string trainer_name)
        {
            ViewBag.trainer_id = trainer_id;
            ViewBag.trainer_name = trainer_name;
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Name", "Name");
            return View("Create");
        }

        // POST: ClassCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Training Staff")]
        public ActionResult Create(string classTrainerId,[Bind(Include = "Id,ClassName,Description,DateFrom,DateTo, Course")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                var trainer = db.Users.Find(classTrainerId);
                if (trainer != null)
                    classCourse.Trainer = trainer;
                db.ClassCourse.Add(classCourse);
                db.SaveChanges();
                this.AddNotification("Create Success", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Name", "Name");
            this.AddNotification("Create Fail", NotificationType.ERROR);
            return View(classCourse);
        }

        // GET: ClassCourses/Edit/5
        [Authorize(Roles = "Admin,Training Staff")]
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
            ViewBag.Course = new SelectList(db.Courses.ToList(), "Name", "Name");
            return View(classCourse);
        }

        // POST: ClassCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Training Staff")]
        public ActionResult Edit(string classTrainerId, [Bind(Include = "Id,ClassName,Description,DateFrom,DateTo,CreateDate, Course")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                var trainer = db.Users.Find(classTrainerId);
                if (trainer != null)
                    classCourse.Trainer = trainer;
                db.Entry(classCourse).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Course = new SelectList(db.Courses.ToList(), "Name", "Name");
                this.AddNotification("Edit Success", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("Edit Fail", NotificationType.ERROR);
            return View(classCourse);
        }

        // GET: ClassCourses/Delete/5
        [Authorize(Roles = "Admin,Training Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourse.Find(id);
            string query = "Select dbo.AspNetUsers.FullName from dbo.AspNetUsers,dbo.ClassCourses where (dbo.AspNetUsers.Id = dbo.ClassCourses.Trainer_Id) AND (dbo.ClassCourses.Id = " + id.Value + ")";
            var queryResult = db.Database.SqlQuery<string>(query);
            string name = queryResult.FirstOrDefault();
            if (name == null) name = "Not Assigned";
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.trainer_name = name;
            return View(classCourse);
        }

        // POST: ClassCourses/Delete/5
        [Authorize(Roles = "Admin,Training Staff")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassCourse classCourse = db.ClassCourse.Find(id);
            db.ClassCourse.Remove(classCourse);
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
