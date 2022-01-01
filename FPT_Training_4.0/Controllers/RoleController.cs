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
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
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
                return View(role);
            }
            context.Entry(role).State = EntityState.Modified;
            context.SaveChanges();
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
            return RedirectToAction("Index");
        }
    }
}