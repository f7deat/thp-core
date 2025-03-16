using Microsoft.EntityFrameworkCore.Storage;

namespace THPCore.Interfaces;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> FindAsync(int id);
    Task<T?> FindAsync(long id);
    Task<T?> FindAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> CountAsync();
    Task<int> SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
}
