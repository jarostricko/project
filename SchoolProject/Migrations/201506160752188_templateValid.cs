namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class templateValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestTemplate", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestTemplate", "Name", c => c.String());
        }
    }
}
