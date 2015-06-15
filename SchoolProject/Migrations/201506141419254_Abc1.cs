namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "QText", c => c.String());
            DropColumn("dbo.Question", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "Text", c => c.String());
            DropColumn("dbo.Question", "QText");
        }
    }
}
