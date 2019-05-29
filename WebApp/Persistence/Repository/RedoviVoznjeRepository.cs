using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models.Gradski_Saobracaj;

namespace WebApp.Persistence.Repository
{
    public class RedoviVoznjeRepository : Repository<RedVoznje, int>, IRedoviVoznjeRepository
    {
        public RedoviVoznjeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return context as ApplicationDbContext; }
        }
    }
}