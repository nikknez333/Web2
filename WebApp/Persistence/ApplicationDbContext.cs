using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebApp.Models;
using WebApp.Models.Gradski_Saobracaj;

namespace WebApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CenaStavke> CeneStavki { get; set; }
        public DbSet<Cenovnik> Cenovnici { get; set; }
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Koeficijent> Koeficijenti { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Linija> Linije { get; set; }
        public DbSet<Putnici> Putnici { get; set; }
        public DbSet<RedVoznje> RedoviVoznji { get; set; }
        public DbSet<Rola> Role { get; set; }
        public DbSet<Stanica> Stanice { get; set; }
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<TipDana> TipoviDana { get; set; }
        public DbSet<TipPutnika> TipoviPutnika { get; set; }
        public DbSet<TipSaobracaja> TipoviSaobracaja { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
    }
}