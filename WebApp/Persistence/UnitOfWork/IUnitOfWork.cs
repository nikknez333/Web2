using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRedoviVoznjeRepository RedoviVoznje { get; }
        ITipSaobracajaRepository TipSaobracaja { get; }
        ITipPutnikaRepository TipPutnika { get; }
        ITipDanaRepository TipDana { get; }
        IStavkaRepository Stavka { get; }
        IStanicaRepository Stanica { get; }
        IPutniciRepository Putnici { get; }
        ILinijaRepository Linija { get; }
        IKorisnikRepository Korisnik { get; }
        IKartaRepository Karta { get; }
        ICenovnikRepository Cenovnik { get; }
        ICenaStavkeRepository CenaStavke { get; }
        int Complete();
    }
}
