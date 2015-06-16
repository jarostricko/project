namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "SureName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Student", "SureName", c => c.String(maxLength: 50));
        }
    }
}
