namespace FPT_Training_4._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassCourseFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.ClassCourses", new[] { "Course_Id" });
            AddColumn("dbo.ClassCourses", "Course", c => c.String());
            DropColumn("dbo.ClassCourses", "Course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassCourses", "Course_Id", c => c.Int());
            DropColumn("dbo.ClassCourses", "Course");
            CreateIndex("dbo.ClassCourses", "Course_Id");
            AddForeignKey("dbo.ClassCourses", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
