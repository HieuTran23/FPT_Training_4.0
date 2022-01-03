namespace FPT_Training_4._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                        Trainer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Trainer_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Trainer_Id);
            
            CreateTable(
                "dbo.UserClasses",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserClassClassCourses",
                c => new
                    {
                        UserClass_UserId = c.Int(nullable: false),
                        ClassCourse_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserClass_UserId, t.ClassCourse_Id })
                .ForeignKey("dbo.UserClasses", t => t.UserClass_UserId, cascadeDelete: true)
                .ForeignKey("dbo.ClassCourses", t => t.ClassCourse_Id, cascadeDelete: true)
                .Index(t => t.UserClass_UserId)
                .Index(t => t.ClassCourse_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserClassClassCourses", "ClassCourse_Id", "dbo.ClassCourses");
            DropForeignKey("dbo.UserClassClassCourses", "UserClass_UserId", "dbo.UserClasses");
            DropForeignKey("dbo.ClassCourses", "Trainer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.UserClassClassCourses", new[] { "ClassCourse_Id" });
            DropIndex("dbo.UserClassClassCourses", new[] { "UserClass_UserId" });
            DropIndex("dbo.ClassCourses", new[] { "Trainer_Id" });
            DropIndex("dbo.ClassCourses", new[] { "Course_Id" });
            DropTable("dbo.UserClassClassCourses");
            DropTable("dbo.UserClasses");
            DropTable("dbo.ClassCourses");
        }
    }
}
