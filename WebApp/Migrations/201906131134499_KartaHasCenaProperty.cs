namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KartaHasCenaProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kartas", "Cena", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kartas", "Cena");
        }
    }
}
