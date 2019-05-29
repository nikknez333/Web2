namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CenaStavkes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cena = c.Double(nullable: false),
                        Cenovnik_Id = c.Int(),
                        Stavka_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cenovniks", t => t.Cenovnik_Id)
                .ForeignKey("dbo.Stavkas", t => t.Stavka_Id)
                .Index(t => t.Cenovnik_Id)
                .Index(t => t.Stavka_Id);
            
            CreateTable(
                "dbo.Cenovniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum_Pocetak = c.DateTime(nullable: false),
                        Datum_Kraj = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VremeKupovine = c.DateTime(nullable: false),
                        CenaStavke_Id = c.Int(),
                        Kupac_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenaStavkes", t => t.CenaStavke_Id)
                .ForeignKey("dbo.Korisniks", t => t.Kupac_Id)
                .Index(t => t.CenaStavke_Id)
                .Index(t => t.Kupac_Id);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Adresa = c.String(),
                        Password = c.String(),
                        IsVerified = c.Boolean(nullable: false),
                        Rola_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rolas", t => t.Rola_Id)
                .Index(t => t.Rola_Id);
            
            CreateTable(
                "dbo.Rolas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Koeficijents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RedniBroj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresa = c.String(),
                        GeoKoordinate = c.String(),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Putnicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Korisnik_Id = c.Int(),
                        TipPutnika_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_Id)
                .ForeignKey("dbo.TipPutnikas", t => t.TipPutnika_Id)
                .Index(t => t.Korisnik_Id)
                .Index(t => t.TipPutnika_Id);
            
            CreateTable(
                "dbo.TipPutnikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RedVoznjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Polazak = c.DateTime(nullable: false),
                        IzabranaLinija_Id = c.Int(),
                        IzabranTipDana_Id = c.Int(),
                        IzabranTipSaobracaja_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linijas", t => t.IzabranaLinija_Id)
                .ForeignKey("dbo.TipDanas", t => t.IzabranTipDana_Id)
                .ForeignKey("dbo.TipSaobracajas", t => t.IzabranTipSaobracaja_Id)
                .Index(t => t.IzabranaLinija_Id)
                .Index(t => t.IzabranTipDana_Id)
                .Index(t => t.IzabranTipSaobracaja_Id);
            
            CreateTable(
                "dbo.TipDanas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipSaobracajas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Id = c.Int(nullable: false),
                        Linija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stanica_Id, t.Linija_Id })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Id, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_Id, cascadeDelete: true)
                .Index(t => t.Stanica_Id)
                .Index(t => t.Linija_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RedVoznjes", "IzabranTipSaobracaja_Id", "dbo.TipSaobracajas");
            DropForeignKey("dbo.RedVoznjes", "IzabranTipDana_Id", "dbo.TipDanas");
            DropForeignKey("dbo.RedVoznjes", "IzabranaLinija_Id", "dbo.Linijas");
            DropForeignKey("dbo.Putnicis", "TipPutnika_Id", "dbo.TipPutnikas");
            DropForeignKey("dbo.Putnicis", "Korisnik_Id", "dbo.Korisniks");
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropForeignKey("dbo.Korisniks", "Rola_Id", "dbo.Rolas");
            DropForeignKey("dbo.Kartas", "Kupac_Id", "dbo.Korisniks");
            DropForeignKey("dbo.Kartas", "CenaStavke_Id", "dbo.CenaStavkes");
            DropForeignKey("dbo.CenaStavkes", "Stavka_Id", "dbo.Stavkas");
            DropForeignKey("dbo.CenaStavkes", "Cenovnik_Id", "dbo.Cenovniks");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropIndex("dbo.RedVoznjes", new[] { "IzabranTipSaobracaja_Id" });
            DropIndex("dbo.RedVoznjes", new[] { "IzabranTipDana_Id" });
            DropIndex("dbo.RedVoznjes", new[] { "IzabranaLinija_Id" });
            DropIndex("dbo.Putnicis", new[] { "TipPutnika_Id" });
            DropIndex("dbo.Putnicis", new[] { "Korisnik_Id" });
            DropIndex("dbo.Korisniks", new[] { "Rola_Id" });
            DropIndex("dbo.Kartas", new[] { "Kupac_Id" });
            DropIndex("dbo.Kartas", new[] { "CenaStavke_Id" });
            DropIndex("dbo.CenaStavkes", new[] { "Stavka_Id" });
            DropIndex("dbo.CenaStavkes", new[] { "Cenovnik_Id" });
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.TipSaobracajas");
            DropTable("dbo.TipDanas");
            DropTable("dbo.RedVoznjes");
            DropTable("dbo.TipPutnikas");
            DropTable("dbo.Putnicis");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
            DropTable("dbo.Koeficijents");
            DropTable("dbo.Rolas");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Kartas");
            DropTable("dbo.Stavkas");
            DropTable("dbo.Cenovniks");
            DropTable("dbo.CenaStavkes");
        }
    }
}
