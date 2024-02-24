using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.DataAccess.Context;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.DataAccess.Repositories;
internal class Repository<T>(AppDbContext context) : IRepository<T>
    where T : class
{
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken)
    {
        await context.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public void UpdateRange(List<T> entities)
    {
        context.Set<T>().UpdateRange(entities);
    }

    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public void RemoveRange(List<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await context.Set<T>().AnyAsync(predicate, cancellationToken);
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsQueryable();
    }

    public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await context.Set<T>().Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Where(predicate).AsQueryable();
    }

    public bool Any(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Any(predicate);
    }
}