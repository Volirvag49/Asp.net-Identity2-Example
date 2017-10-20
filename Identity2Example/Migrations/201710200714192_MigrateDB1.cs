namespace Identity2Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "About", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "About", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
