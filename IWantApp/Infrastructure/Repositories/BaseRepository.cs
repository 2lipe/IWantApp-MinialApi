using IWantApp.Domain;
using IWantApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IList<TEntity>> GetAllAsync(int page, int pageSize)
    {
        var data = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Skip(page * pageSize)
            .Take(pageSize)
            .OrderByDescending(x => x.UpdatedAt)
            .ToListAsync();

        return data;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var data = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (data == null)
            return null;

        return data;
    }

    public async Task<bool> AddAsync(TEntity entity)
    {
        var data = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        if (data.State != EntityState.Unchanged)
            return false;

        return true;
    }

    public async Task<bool> AddRangeAsync(IList<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        var data = await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var data = _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateRangeAsync(IList<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        var data = _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<TEntity>().CountAsync();
    }
}