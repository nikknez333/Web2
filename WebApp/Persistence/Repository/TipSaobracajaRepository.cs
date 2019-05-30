using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Gradski_Saobracaj;

namespace WebApp.Persistence.Repository
{
    public class TipSaobracajaRepository : Repository<TipSaobracaja, int>, ITipSaobracajaRepository
    {
        public TipSaobracajaRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return context as ApplicationDbContext; }
        }
    }
}