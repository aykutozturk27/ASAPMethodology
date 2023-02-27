using ASAPMethodology.Core.Entities;
using System.Linq.Expressions;

namespace ASAPMethodology.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        #region Sync Functions
        List<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        #endregion

        #region Async Functions
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        #endregion
    }
}
