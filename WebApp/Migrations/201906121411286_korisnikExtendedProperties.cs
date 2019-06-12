namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class korisnikExtendedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "Status", c => c.String());
            AddColumn("dbo.Korisniks", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "ImageUrl");
            DropColumn("dbo.Korisniks", "Status");
        }
    }
}
