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