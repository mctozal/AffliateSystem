using MeSoft.Core.Repositories;
using MeSoft.Shared.EntityBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.Core.WebApi.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeSoft.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {


        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {

            entity.CreatedByUserId = 1;
            entity.CreatedAt = DateTime.Now;
            entity.IsDeleted = false;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
             _context.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);

            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public async Task Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = await GetById(predicate);

            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();

        }


        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetAllQuery()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

        }

        public void UpdateRange(List<T> entity)
        {
            _dbSet.UpdateRange(entity);
            _context.SaveChanges();

        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public Task<bool> Contains(T entity)
        {
            return _dbSet.ContainsAsync(entity);
        }

    }
}
