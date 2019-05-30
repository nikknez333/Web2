using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
      
        public DemoUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            RedoviVoznje = new RedoviVoznjeRepository(_context);
        }

        public IRedoviVoznjeRepository RedoviVoznje { get; private set; }
        public ITipSaobracajaRepository TipSaobracaja { get; private set; }
        public ITipPutnikaRepository TipPutnika { get; private set; }
        public ITipDanaRepository TipDana { get; private set; }
        public IStavkaRepository Stavka { get; private set; }
        public IStanicaRepository Stanica { get; private set; }
        public IPutniciRepository Putnici { get; private set; }
        public ILinijaRepository Linija { get; private set; }
        public IKorisnikRepository Korisnik { get; private set; }
        public IKartaRepository Karta { get; private set; }
        public ICenovnikRepository Cenovnik { get; private set; }
        public ICenaStavkeRepository CenaStavke { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}