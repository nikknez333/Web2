namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatLon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stanicas", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Stanicas", "Lon", c => c.Double(nullable: false));
            DropColumn("dbo.Stanicas", "GeoKoordinate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stanicas", "GeoKoordinate", c => c.String());
            DropColumn("dbo.Stanicas", "Lon");
            DropColumn("dbo.Stanicas", "Lat");
        }
    }
}
