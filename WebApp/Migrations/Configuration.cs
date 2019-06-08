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
            //Linija lin1 = new Models.Gradski_Saobracaj.Linija() { Id = 2, RedniBroj = "5b", Stanice = null };
            //Linija lin2 = new Models.Gradski_Saobracaj.Linija() { Id = 3, RedniBroj = "7a", Stanice = null };
            //Linija lin3 = new Models.Gradski_Saobracaj.Linija() { Id = 4, RedniBroj = "12", Stanice = null };
            //TipSaobracaja tipSaobracaja1 = new TipSaobracaja() { Id = 1, Naziv = "Gradski" };
            //TipSaobracaja tipSaobracaja2 = new TipSaobracaja() { Id = 2, Naziv = "Medjugradski" };
            //TipDana tipDana1 = new TipDana() { Id = 55, Naziv = "Radni Dan" };
            //TipDana tipDana2 = new TipDana() { Id = 66, Naziv = "Subota" };
            //TipDana tipDana3 = new TipDana() { Id = 77, Naziv = "Nedelja" };

            //context.Linije.Add(lin1);
            //context.Linije.Add(lin2);
            //context.Linije.Add(lin3);


            //context.TipoviSaobracaja.Add(tipSaobracaja1);
            //context.TipoviSaobracaja.Add(tipSaobracaja2);

            //context.TipoviDana.Add(tipDana1);
            //context.TipoviDana.Add(tipDana2);
            //context.TipoviDana.Add(tipDana3);

            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 1, IzabranaLinija = lin1, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = DateTime.Now });
            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 2, IzabranaLinija = lin1, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = new DateTime(2019, 8, 3, 13, 40, 0) });
            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 3, IzabranaLinija = lin2, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = new DateTime(2019, 8, 3, 13, 53, 0) });
            //context.RedoviVoznji.AddOrUpdate(rv => rv.Id, new Models.Gradski_Saobracaj.RedVoznje() { Id = 4, IzabranaLinija = lin2, IzabranTipDana = tipDana1, IzabranTipSaobracaja = tipSaobracaja1, Polazak = new DateTime(2019, 8, 3, 14, 10, 0) });
            //context.SaveChanges();

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
        }
    }
}
