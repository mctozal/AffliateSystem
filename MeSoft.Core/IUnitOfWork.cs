using Microsoft.EntityFrameworkCore.Storage;
using MeSoft.Core.Repositories;
using MeSoft.Shared.EntityBase;

namespace MeSoft.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : EntityBase; 
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
