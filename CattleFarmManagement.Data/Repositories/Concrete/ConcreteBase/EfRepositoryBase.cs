using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Repositories.Concrete.ConcreteBase
{
    public class EfRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfRepositoryBase(DbContext context)
        {
            _context = context;
        }


        #region Add Async
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        #endregion

        #region Update Async
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
            return entity;
        }
        #endregion

        #region Delete Async
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int Id)
        {
            var deletedId = await _context.Set<TEntity>().FindAsync(Id);
            await Task.Run(() => { _context.Set<TEntity>().Remove(deletedId); });
        }
        #endregion

        #region GetAll Async
        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? await _context.Set<TEntity>().ToListAsync()
                                     : await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        #endregion

        #region GetAll With Include Async
        /// <summary>
        /// GetAll with Include
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperty"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllWithIncludeAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperty)
        {

            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperty.Any())
            {
                foreach (var item in includeProperty)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }
        #endregion

        #region Get Async
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).SingleAsync();

        }
        #endregion

        #region Get With Include Async
        /// <summary>
        /// Get with Include
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperty"></param>
        /// <returns></returns>
        public async Task<TEntity> GetWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperty)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperty.Any())
            {
                foreach (var item in includeProperty)
                {
                    query = query.Include(item);
                }
            }
            return await query.SingleAsync();
        }
        #endregion

        

        


    }
}
