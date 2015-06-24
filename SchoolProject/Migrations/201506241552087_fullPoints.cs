namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestTemplate", "FullPoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestTemplate", "FullPoints");
        }
    }
}
