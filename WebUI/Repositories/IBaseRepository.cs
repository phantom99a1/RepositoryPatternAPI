using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using WebUI.Data;

namespace WebUI.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        public IQueryable<T> GetQueryable();
        public ApplicationDbContext GetContext();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
