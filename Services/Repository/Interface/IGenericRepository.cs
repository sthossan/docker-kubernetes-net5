using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllByExpression(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T Find(params object[] keyValues);
        Task<T> FindAsync(params object[] keyValues);
        Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues);

        Task InsertAsync(T entity);
        Task InsertRange(List<T> entity);

        Task UpdateAsync(T entity);
        Task UpdateRange(List<T> entity);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task DeleteRangeAsync(ICollection<T> entities);

        Task<int> SaveAsync();

        Task<ICollection<T>> RunSqlQueryAsync(string sqlQuery);
        IQueryable<T> RunSqlQueryAsQueryable(string sqlQuery);
    }
}
