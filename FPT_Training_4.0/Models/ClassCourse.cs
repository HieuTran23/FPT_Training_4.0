using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPT_Training_4._0.Models
{
    public class UserClass
    {
        public UserClass()
        {
            CreateDate = DateTime.Now;
            this.ClassCourse = new HashSet<ClassCourse>();
        }

        [Key]
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<ClassCourse> ClassCourse { get; set; }
    }


    public class ClassCourse
    {
        public ClassCourse()
        {
            CreateDate = DateTime.Now;
            this.UserClass = new HashSet<UserClass>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ClassName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public ApplicationUser Trainer { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<UserClass> UserClass { get; set; }

        public string Course { get; set; }
    }
}