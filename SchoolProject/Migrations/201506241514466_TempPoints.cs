namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "TempPoints", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answer", "TempPoints");
        }
    }
}
