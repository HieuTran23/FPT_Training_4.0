using FPT_Training_4._0.Extensions;
using FPT_Training_4._0.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FPT_Training_4._0.Controllers
{
    [Authorize(Roles = "Admin,Training Staff")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Role
        public ActionResult Index()
        {
            var roles = context.Roles;
            return View(roles);
        }

        //
        // // Role/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                context.Roles.Add(Role);
                context.SaveChanges();
                this.AddNotification("Create success", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("Create Fail", NotificationType.ERROR);
            return View("Create");
        }
        //
        // Role/Edit

        //GET
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roles = context.Roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            if (!ModelState.IsValid)
            {
                this.AddNotification("Edit Fail", NotificationType.ERROR);
                return View(role);
            }
            context.Entry(role).State = EntityState.Modified;
            context.SaveChanges();
            this.AddNotification("Edit success", NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // Role/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = context.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            context.Roles.Remove(role);
            context.SaveChanges();
            this.AddNotification("Delete success", NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }
    }
}