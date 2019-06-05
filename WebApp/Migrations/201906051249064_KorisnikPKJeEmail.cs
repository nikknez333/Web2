namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KorisnikPKJeEmail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kartas", "Kupac_Id", "dbo.Korisniks");
            DropForeignKey("dbo.Putnicis", "Korisnik_Id", "dbo.Korisniks");
            DropIndex("dbo.Kartas", new[] { "Kupac_Id" });
            DropIndex("dbo.Putnicis", new[] { "Korisnik_Id" });
            RenameColumn(table: "dbo.Kartas", name: "Kupac_Id", newName: "Kupac_Email");
            RenameColumn(table: "dbo.Putnicis", name: "Korisnik_Id", newName: "Korisnik_Email");
            DropPrimaryKey("dbo.Korisniks");
            AlterColumn("dbo.Kartas", "Kupac_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Korisniks", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Putnicis", "Korisnik_Email", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Korisniks", "Email");
            CreateIndex("dbo.Kartas", "Kupac_Email");
            CreateIndex("dbo.Putnicis", "Korisnik_Email");
            AddForeignKey("dbo.Kartas", "Kupac_Email", "dbo.Korisniks", "Email");
            AddForeignKey("dbo.Putnicis", "Korisnik_Email", "dbo.Korisniks", "Email");
            DropColumn("dbo.Korisniks", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Korisniks", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Putnicis", "Korisnik_Email", "dbo.Korisniks");
            DropForeignKey("dbo.Kartas", "Kupac_Email", "dbo.Korisniks");
            DropIndex("dbo.Putnicis", new[] { "Korisnik_Email" });
            DropIndex("dbo.Kartas", new[] { "Kupac_Email" });
            DropPrimaryKey("dbo.Korisniks");
            AlterColumn("dbo.Putnicis", "Korisnik_Email", c => c.Int());
            AlterColumn("dbo.Korisniks", "Email", c => c.String());
            AlterColumn("dbo.Kartas", "Kupac_Email", c => c.Int());
            AddPrimaryKey("dbo.Korisniks", "Id");
            RenameColumn(table: "dbo.Putnicis", name: "Korisnik_Email", newName: "Korisnik_Id");
            RenameColumn(table: "dbo.Kartas", name: "Kupac_Email", newName: "Kupac_Id");
            CreateIndex("dbo.Putnicis", "Korisnik_Id");
            CreateIndex("dbo.Kartas", "Kupac_Id");
            AddForeignKey("dbo.Putnicis", "Korisnik_Id", "dbo.Korisniks", "Id");
            AddForeignKey("dbo.Kartas", "Kupac_Id", "dbo.Korisniks", "Id");
        }
    }
}
