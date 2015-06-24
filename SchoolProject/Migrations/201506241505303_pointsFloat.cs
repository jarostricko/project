namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pointsFloat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAnswer", "Points", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentAnswer", "Points");
        }
    }
}
