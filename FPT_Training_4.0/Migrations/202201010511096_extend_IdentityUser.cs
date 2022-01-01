namespace FPT_Training_4._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extend_IdentityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
