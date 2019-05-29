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
        DbSet<CenaStavke> CeneStavki { get; set; }
        DbSet<Cenovnik> Cenovnici { get; set; }
        DbSet<Karta> Karte { get; set; }
        DbSet<Koeficijent> Koeficijenti { get; set; }
        DbSet<Korisnik> Korisnici { get; set; }
        DbSet<Linija> Linije { get; set; }
        DbSet<Putnici> Putnici { get; set; }
        DbSet<RedVoznje> RedoviVoznji { get; set; }
        DbSet<Rola> Role { get; set; }
        DbSet<Stanica> Stanice { get; set; }
        DbSet<Stavka> Stavke { get; set; }
        DbSet<TipDana> TipoviDana { get; set; }
        DbSet<TipPutnika> TipoviPutnika { get; set; }
        DbSet<TipSaobracaja> TipoviSaobracaja { get; set; }

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