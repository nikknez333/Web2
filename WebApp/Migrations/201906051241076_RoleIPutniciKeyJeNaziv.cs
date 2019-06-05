namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIPutniciKeyJeNaziv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Korisniks", "Rola_Id", "dbo.Rolas");
            DropForeignKey("dbo.Putnicis", "TipPutnika_Id", "dbo.TipPutnikas");
            DropIndex("dbo.Korisniks", new[] { "Rola_Id" });
            DropIndex("dbo.Putnicis", new[] { "TipPutnika_Id" });
            RenameColumn(table: "dbo.Korisniks", name: "Rola_Id", newName: "Rola_Naziv");
            RenameColumn(table: "dbo.Putnicis", name: "TipPutnika_Id", newName: "TipPutnika_Naziv");
            DropPrimaryKey("dbo.Rolas");
            DropPrimaryKey("dbo.TipPutnikas");
            AddColumn("dbo.Rolas", "Sifra", c => c.Int(nullable: false));
            AddColumn("dbo.TipPutnikas", "Sifra", c => c.Int(nullable: false));
            AlterColumn("dbo.Korisniks", "Rola_Naziv", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rolas", "Naziv", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Putnicis", "TipPutnika_Naziv", c => c.String(maxLength: 128));
            AlterColumn("dbo.TipPutnikas", "Naziv", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Rolas", "Naziv");
            AddPrimaryKey("dbo.TipPutnikas", "Naziv");
            CreateIndex("dbo.Korisniks", "Rola_Naziv");
            CreateIndex("dbo.Putnicis", "TipPutnika_Naziv");
            AddForeignKey("dbo.Korisniks", "Rola_Naziv", "dbo.Rolas", "Naziv");
            AddForeignKey("dbo.Putnicis", "TipPutnika_Naziv", "dbo.TipPutnikas", "Naziv");
            DropColumn("dbo.Rolas", "Id");
            DropColumn("dbo.TipPutnikas", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipPutnikas", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Rolas", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Putnicis", "TipPutnika_Naziv", "dbo.TipPutnikas");
            DropForeignKey("dbo.Korisniks", "Rola_Naziv", "dbo.Rolas");
            DropIndex("dbo.Putnicis", new[] { "TipPutnika_Naziv" });
            DropIndex("dbo.Korisniks", new[] { "Rola_Naziv" });
            DropPrimaryKey("dbo.TipPutnikas");
            DropPrimaryKey("dbo.Rolas");
            AlterColumn("dbo.TipPutnikas", "Naziv", c => c.String());
            AlterColumn("dbo.Putnicis", "TipPutnika_Naziv", c => c.Int());
            AlterColumn("dbo.Rolas", "Naziv", c => c.String());
            AlterColumn("dbo.Korisniks", "Rola_Naziv", c => c.Int());
            DropColumn("dbo.TipPutnikas", "Sifra");
            DropColumn("dbo.Rolas", "Sifra");
            AddPrimaryKey("dbo.TipPutnikas", "Id");
            AddPrimaryKey("dbo.Rolas", "Id");
            RenameColumn(table: "dbo.Putnicis", name: "TipPutnika_Naziv", newName: "TipPutnika_Id");
            RenameColumn(table: "dbo.Korisniks", name: "Rola_Naziv", newName: "Rola_Id");
            CreateIndex("dbo.Putnicis", "TipPutnika_Id");
            CreateIndex("dbo.Korisniks", "Rola_Id");
            AddForeignKey("dbo.Putnicis", "TipPutnika_Id", "dbo.TipPutnikas", "Id");
            AddForeignKey("dbo.Korisniks", "Rola_Id", "dbo.Rolas", "Id");
        }
    }
}
