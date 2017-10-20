namespace Identity2Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "About", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "About");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "DOB");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
