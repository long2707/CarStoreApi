using CarStoreApi.Application.Interfaces;
using CarStoreApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.Repositorries;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<T?>> GetAllAsync()
    {
        return await Task.Run(() => _context.Set<T>().AsNoTracking().AsQueryable());

    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> criteria, string[]? includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (query is null) return null;
        if (includes != null)
        {
            foreach(var include in includes)
                query = query.AsNoTracking().Include(include);
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(criteria);    
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria) => await Task.Run(() => _context.Set<T>().Where(criteria).AsQueryable());

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.Run(() =>
        {
            _context.Set<T>().Update(entity);
        });

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() =>
        {
            _context.Set<T>().Remove(entity!);
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(ICollection<T> entities)
    {
        await Task.Run(() =>
        {
            _context.Set<T>().RemoveRange(entities);
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWhereAsync(Expression<Func<T, bool>> criteria)
    {
        await _context.Set<T>().Where(criteria).ExecuteDeleteAsync();
    }
    public async Task<List<TResult>> CustomFindAsync<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null,
        CancellationToken cancellationToken = default) where TEntity : class
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes != null)
        {
            query = includes(query);
        }

        if (predicate != null)
            return await _context.Set<TEntity>()
                .Where(predicate)
                .Select(selector)
                .ToListAsync(cancellationToken);

        return await _context.Set<TEntity>()
            .Select(selector)
            .ToListAsync(cancellationToken);
    }

 
}

