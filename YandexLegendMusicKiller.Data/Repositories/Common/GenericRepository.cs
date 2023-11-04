using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Common;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly YandexLegendMusicKillerDbContext _dbContext;
    protected readonly DbSet<TEntity> EntitySet;

    internal GenericRepository(YandexLegendMusicKillerDbContext dbContext)
    {
        _dbContext = dbContext;
        EntitySet = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await EntitySet.AddAsync(entity, ct);
        await _dbContext.SaveChangesAsync(ct);
    }

    public void Update(TEntity entity)
    {
        EntitySet.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        EntitySet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
        => await EntitySet.FirstOrDefaultAsync(expression, ct);

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await EntitySet.ToListAsync(ct);

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
        => await EntitySet.Where(expression).ToListAsync(ct);
}