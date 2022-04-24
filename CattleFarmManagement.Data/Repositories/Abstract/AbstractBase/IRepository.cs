using CattleFarmManagement.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Repositories.Abstract.AbstractBase
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int Id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperty);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperty);
    }
}
