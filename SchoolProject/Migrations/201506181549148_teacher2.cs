namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacher2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
        }
    }
}
