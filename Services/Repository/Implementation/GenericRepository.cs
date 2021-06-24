using Microsoft.EntityFrameworkCore;
using Models.DataContext;
using Services.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Repository.Implementation
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EfDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(EfDbContext context)
        {
            _dbContext = context;
            if (context is DbContext dbContext) _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }
        public virtual IQueryable<T> GetAllByExpression(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().Where(predicate);
            return query;
        }
        public virtual async Task<ICollection<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
            // return _dbContext.Set<T>();
        }
        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual T Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
        public async Task<T> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }
        public async Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dbSet.FindAsync(cancellationToken, keyValues);
        }

        public virtual async Task InsertAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }
        public virtual async Task InsertRange(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }
        public virtual async Task UpdateAsync(T entity)
        {
            await Task.FromResult(_dbContext.Set<T>().Update(entity));
        }
        public virtual async Task UpdateRange(List<T> entities)
        {
            await Task.Delay(500);
            _dbContext.Set<T>().UpdateRange(entities);
        }


        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

            await Task.Run(() => _dbContext.Set<T>().Remove(entity));
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            //await Task.Delay(500);
            await Task.Run(() => _dbContext.Set<T>().RemoveRange(entities));
        }
        public virtual async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<ICollection<T>> RunSqlQueryAsync(string sqlQuery)
        {
            return await _dbContext.Set<T>().FromSqlRaw(sqlQuery).ToListAsync();
        }
        public virtual IQueryable<T> RunSqlQueryAsQueryable(string sqlQuery)
        {
            return _dbContext.Set<T>().FromSqlRaw(sqlQuery).AsNoTracking();
        }
    }
}
