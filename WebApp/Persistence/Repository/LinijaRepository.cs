using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Gradski_Saobracaj;

namespace WebApp.Persistence.Repository
{
    public class LinijaRepository : Repository<Linija,int>, ILinijaRepository
    {
        public LinijaRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return context as ApplicationDbContext; }
        }
    }
}