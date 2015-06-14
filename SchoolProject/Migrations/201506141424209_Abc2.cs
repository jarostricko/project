namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abc2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "Text", c => c.String());
            DropColumn("dbo.Question", "QText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "QText", c => c.String());
            DropColumn("dbo.Question", "Text");
        }
    }
}
