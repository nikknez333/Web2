namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;
    using WebApp.Models.Gradski_Saobracaj;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Initial TEST data
            //executes every time update-database is called
            //Linija lin1 = new Models.Gradski_Saobracaj.Linija() { Id = 1, RedniBroj = "5b", Stanice = new System.Collections.Generic.List<Stanica>() };
            //Linija lin2 = new Models.Gradski_Saobracaj.Linija() { Id = 3, RedniBroj = "7a", Stanice = new System.Collections.Generic.List<Stanica>() };
            //Linija lin3 = new Models.Gradski_Saobracaj.Linija() { Id = 2, RedniBroj = "12", Stanice = new System.Collections.Generic.List<Stanica>() };
            //TipSaobracaja tipSaobracaja1 = new TipSaobracaja() { Id = 1, Naziv = "Gradski" };
            //TipSaobracaja tipSaobracaja2 = new TipSaobracaja() { Id = 2, Naziv = "Medjugradski" };
            //TipDana tipDana1 = new TipDana() { Id = 55, Naziv = "Radni Dan" };
            //TipDana tipDana2 = new TipDana() { Id = 66, Naziv = "Subota" };
            //TipDana tipDana3 = new TipDana() { Id = 77, Naziv = "Nedelja" };

            //context.Linije.Add(lin1);
            //context.Linije.Add(lin2);
            //context.Linije.Add(lin3);


            //context.TipoviSaobracaja.AddOrUpdate(tipSaobracaja1);
            //context.TipoviSaobracaja.AddOrUpdate(tipSaobracaja2);

            //context.TipoviDana.AddOrUpdate(tipDana1);
            //context.TipoviDana.AddOrUpdate(tipDana2);
            //context.TipoviDana.AddOrUpdate(tipDana3);

            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 1, IzabranaLinija = lin1, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = DateTime.Now });
            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 2, IzabranaLinija = lin1, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = new DateTime(2019, 8, 3, 13, 40, 0) });
            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 3, IzabranaLinija = lin2, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = new DateTime(2019, 8, 3, 13, 53, 0) });
            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 4, IzabranaLinija = lin2, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = new DateTime(2019, 8, 3, 14, 10, 0) });

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }

            //Stavka vremenskaKarta = new Stavka() { Id = 1, Naziv = "Vremenska karta" };
            //Stavka dnevnaKarta = new Stavka() { Id = 2, Naziv = "Dnevna karta" };
            //Stavka mesecnaKarta = new Stavka() { Id = 3, Naziv = "Mesecna karta" };
            //Stavka godisnjaKarta = new Stavka() { Id = 4, Naziv = "Godisnja karta" };

            //Cenovnik prolecniCenovnik = new Cenovnik { Id = 1, Datum_Pocetak = new DateTime(2019, 4, 25), Datum_Kraj = new DateTime(2019, 12, 12), IsActive = true };

            //context.Stavke.AddOrUpdate(vremenskaKarta);
            //context.Stavke.AddOrUpdate(dnevnaKarta);
            //context.Stavke.AddOrUpdate(mesecnaKarta);
            //context.Stavke.AddOrUpdate(godisnjaKarta);
            //context.Cenovnici.AddOrUpdate(prolecniCenovnik);

            //CenaStavke vremenskaKartaStv = new CenaStavke() { Id = 1, Cenovnik = prolecniCenovnik, Stavka = vremenskaKarta, Cena = 1.5 };
            //CenaStavke dnevnaKartaStv = new CenaStavke() { Id = 2, Cenovnik = prolecniCenovnik, Stavka = dnevnaKarta, Cena = 3.5 };
            //CenaStavke mesecnaKartaStv = new CenaStavke() { Id = 3, Cenovnik = prolecniCenovnik, Stavka = mesecnaKarta, Cena = 7.5 };
            //CenaStavke godisnjaKartaStv = new CenaStavke() { Id = 4, Cenovnik = prolecniCenovnik, Stavka = godisnjaKarta, Cena = 15.0 };

            //context.CeneStavki.AddOrUpdate(vremenskaKartaStv);
            //context.CeneStavki.AddOrUpdate(dnevnaKartaStv);
            //context.CeneStavki.AddOrUpdate(mesecnaKartaStv);
            //context.CeneStavki.AddOrUpdate(godisnjaKartaStv);



            /*
             * SEED STANICE
             */
            //Stanica s1 = new Stanica() { Id = 1, Naziv = "Jugodrvo", Adresa = "Bulevar Oslobodjenja 112", Lat = 45.242268, Lon = 19.842954, Linije = new System.Collections.Generic.List<Linija>() { lin1 } };
            //Stanica s2 = new Stanica() { Id = 2, Naziv = "Limanski Park", Adresa = "Bulevar Oslobodjenja 143", Lat = 45.241643, Lon = 19.84279, Linije = new System.Collections.Generic.List<Linija>() { lin1 } };
            //Stanica s3 = new Stanica() { Id = 3, Naziv = "Medlab", Adresa = "Bulevar Oslobodjenja 105", Lat = 45.243701, Lon = 19.84161, Linije = new System.Collections.Generic.List<Linija>() { lin1 } };
            //Stanica s4 = new Stanica() { Id = 4, Naziv = "Arteski bunar, ", Adresa = "Bulevar Cara Lazara 85", Lat = 45.24503, Lon = 19.846417, Linije = new System.Collections.Generic.List<Linija>() { lin1 } };
            //Stanica s5 = new Stanica() { Id = 5, Naziv = "Univerzitet", Adresa = "Bulevar Cara Lazara 120", Lat = 45.249784, Lon = 19.855412, Linije = new System.Collections.Generic.List<Linija>() { lin1 } };
            //lin1.Stanice.Add(s1);
            //lin1.Stanice.Add(s2);
            //lin1.Stanice.Add(s3);
            //lin1.Stanice.Add(s4);
            //lin1.Stanice.Add(s5);

            //context.Stanice.AddOrUpdate(s1);
            //context.Stanice.AddOrUpdate(s2);
            //context.Stanice.AddOrUpdate(s3);
            //context.Stanice.AddOrUpdate(s4);
            //context.Stanice.AddOrUpdate(s5);

            //context.SaveChanges();
        }
    } }