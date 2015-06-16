namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ThematicField", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ThematicField", "Title", c => c.String());
        }
    }
}
