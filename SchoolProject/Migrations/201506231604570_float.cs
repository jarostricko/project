namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _float : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentsTest", "Points", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentsTest", "Points", c => c.Int(nullable: false));
        }
    }
}
