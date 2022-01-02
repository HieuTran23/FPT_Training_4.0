using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPT_Training_4._0.Models
{
    public class Course
    {
        public Course()
        {
            CreateDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeCourse { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}