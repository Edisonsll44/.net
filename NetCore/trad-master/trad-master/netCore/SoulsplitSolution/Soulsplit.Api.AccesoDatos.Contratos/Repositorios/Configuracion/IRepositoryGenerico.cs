using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface IRepositoryGenerico<T> where T : IBaseWithIdEntity
    {
        Task<bool> Exists(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task DeleteAsync(Guid id);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
        TEntity GetOneOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
        Task CreateRange<TEntity>(IEnumerable<TEntity> entities, string createdBy = null) where TEntity : class;
        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
        Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;
    }
}
