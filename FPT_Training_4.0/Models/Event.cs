using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPT_Training_4._0.Models
{
    public class Event
    {
        public Event()
        {
            CreateDate = DateTime.Now;
            this.StartDateTime = DateTime.Now;
            IsPublic = true;
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Tiltle { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string AuthorId { get; set; }

        public string Description { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public bool IsPublic { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public string EventId { get; set; }
        [Required]
        public virtual Event Event { get; set; }
    }
}