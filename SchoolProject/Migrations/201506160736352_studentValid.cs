namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "SureName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            AlterColumn("dbo.Student", "SureName", c => c.String());
        }
    }
}
