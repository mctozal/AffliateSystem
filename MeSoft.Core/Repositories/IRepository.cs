using MeSoft.Shared.EntityBase;
using System.Linq.Expressions;

namespace MeSoft.Core.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        public Task AddAsync(T entity);
        public Task AddRange(IEnumerable<T> entity);

        public void Delete(T entity);
        public Task Delete(Guid id);

        public Task Delete(Expression<Func<T, bool>> predicate);
        public void DeleteRange(List<T> entities);

        public Task<List<T>> GetAll();

        public IQueryable<T> GetAllQuery();

        public Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        public Task<T> GetById(Guid id);

        public Task<T> GetById(Expression<Func<T, bool>> predicate);

        public void Update(T entity);

        public void UpdateRange(List<T> entity);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<bool> Contains(T entity);

    }
}
