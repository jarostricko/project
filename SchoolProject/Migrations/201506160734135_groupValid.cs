namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentGroup", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentGroup", "Title", c => c.String());
        }
    }
}
