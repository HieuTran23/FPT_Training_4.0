using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FPT_Training_4._0.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<CourseType> courseTypes { get; set;}

        public System.Data.Entity.DbSet<FPT_Training_4._0.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<FPT_Training_4._0.Models.UserClass> UserClass { get; set; }

        public System.Data.Entity.DbSet<FPT_Training_4._0.Models.ClassCourse> ClassCourse { get; set; }
    }
}