namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "IsTeacher", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "IsTeacher");
        }
    }
}
