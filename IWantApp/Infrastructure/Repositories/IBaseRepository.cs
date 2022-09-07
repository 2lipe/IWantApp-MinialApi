using IWantApp.Domain;

namespace IWantApp.Infrastructure.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<IList<TEntity>> GetAllAsync(int page, int pageSize);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> AddRangeAsync(IList<TEntity> entities);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> UpdateRangeAsync(IList<TEntity> entities);
    Task<bool> DeleteAsync(TEntity entity);
    Task<int> CountAsync();
}