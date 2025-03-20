using MeSoft.Core;
using MeSoft.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace MeSoft.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
      
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private bool disposed = false;


        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repositories.Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
