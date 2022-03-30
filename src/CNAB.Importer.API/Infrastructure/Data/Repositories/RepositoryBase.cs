using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CNAB.Importer.API.Infrastructure.Data.Repositories;

public class RepositoryBase<TEntity> : IAsyncDisposable, IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> DbSet;
    private readonly ImporterContext _context;

    public RepositoryBase(IDbContextFactory<ImporterContext> contextFactory)
    {
        _context = contextFactory.CreateDbContext();
        DbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();

        if (filter != null)
            query = query
                .Where(filter);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public ValueTask DisposeAsync() => _context.DisposeAsync();
}