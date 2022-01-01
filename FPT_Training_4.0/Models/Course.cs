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
            DateCreate = DateTime.Now;    
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; } 
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateBegin { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }

    }
}