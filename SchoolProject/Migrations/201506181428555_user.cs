namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "SureName", c => c.String());
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String());
            AddColumn("dbo.ApplicationUser", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "BirthDate");
            DropColumn("dbo.ApplicationUser", "FirstName");
            DropColumn("dbo.ApplicationUser", "SureName");
        }
    }
}
