namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationStatustableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationStatus",
                c => new
                    {
                        UserEmail = c.String(nullable: false, maxLength: 128),
                        ImageUrl = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.UserEmail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegistrationStatus");
        }
    }
}
