using FPT_Training_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Training_4._0.Controllers
{
    public class ManageUserController : Controller
    {
        ApplicationDbContext context;
        public ManageUserController()
        {
            context = new ApplicationDbContext();
        }

        // GET: ManageUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UserRoleViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }
    }
}