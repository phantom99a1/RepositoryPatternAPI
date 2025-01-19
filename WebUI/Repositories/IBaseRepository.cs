using System.Linq.Expressions;

namespace WebUI.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetValuesAsync(Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includes);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
