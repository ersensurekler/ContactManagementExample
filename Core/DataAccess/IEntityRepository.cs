using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        DbContext CurrentContext { get; }

        #region Listing Methods

        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> QueryableWithTracker();
        DbSet<TEntity> Table();
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);

        Task<ICollection<TEntity>> GetListAsync(
                 Expression<Func<TEntity, bool>> filter = null,
                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                 int skip = 0,
                 int take = int.MaxValue,
                 params Expression<Func<TEntity, object>>[] includes);

        Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);
        Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        #endregion

        #region Queryable Methods
        Task<ICollection<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        #endregion

        #region Single Data Methods
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        #endregion

        #region Add, Update & Delete Methods
        Task Add(TEntity entity);
        Task AddRange(ICollection<TEntity> entities);
        Task AddRangeAsync(ICollection<TEntity> entities);
        Task Update(TEntity entity);
        Task UpdateRange(ICollection<TEntity> entities);
        Task BulkUpdateAsync(ICollection<TEntity> entities);
        Task BulkUpdateAsync(ICollection<TEntity> entities, Action<BulkOperation<TEntity>> options);
        Task<int> UpdateFromQueryAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TEntity>> updateEntity);
        Task<int> DeleteFromQueryAsync(Expression<Func<TEntity, bool>> filter);
        Task UpdatePartial(int id, object entity);
        Task Delete(TEntity entity);
        Task DeleteRange(ICollection<TEntity> entities);
        Task BulkDelete(ICollection<TEntity> entities);
        Task BulkInsertAsync(ICollection<TEntity> entities);
        Task BulkInsertAsync(ICollection<TEntity> entities, Action<BulkOperation<TEntity>> keyOptions);
        #endregion

        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where);
        Task BulkSaveChanges();
    }
}
