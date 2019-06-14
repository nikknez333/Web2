namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimestampAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenaStavkes", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Cenovniks", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stavkas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Kartas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Korisniks", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Rolas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Koeficijents", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Linijas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stanicas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Putnicis", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.TipPutnikas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.RedVoznjes", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.TipDanas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.TipSaobracajas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.RegistrationStatus", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistrationStatus", "Version");
            DropColumn("dbo.TipSaobracajas", "Version");
            DropColumn("dbo.TipDanas", "Version");
            DropColumn("dbo.RedVoznjes", "Version");
            DropColumn("dbo.TipPutnikas", "Version");
            DropColumn("dbo.Putnicis", "Version");
            DropColumn("dbo.Stanicas", "Version");
            DropColumn("dbo.Linijas", "Version");
            DropColumn("dbo.Koeficijents", "Version");
            DropColumn("dbo.Rolas", "Version");
            DropColumn("dbo.Korisniks", "Version");
            DropColumn("dbo.Kartas", "Version");
            DropColumn("dbo.Stavkas", "Version");
            DropColumn("dbo.Cenovniks", "Version");
            DropColumn("dbo.CenaStavkes", "Version");
        }
    }
}
