using System.Linq.Expressions;

namespace NTierAcrh.Entities.Repositories;
public interface IRepository<T>
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);
    void UpdateRange(List<T> entities);
    void Remove(T entity);
    void RemoveRange(List<T> entities);
    Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>>? predicate = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    bool Any(Expression<Func<T, bool>> predicate);
}
