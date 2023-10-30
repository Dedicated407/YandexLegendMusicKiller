using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Common;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly YandexLegendMusicKillerDbContext _dbContext;
    private readonly DbSet<TEntity> _entitySet;

    internal GenericRepository(YandexLegendMusicKillerDbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _entitySet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _entitySet.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        _entitySet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _entitySet.ToListAsync(cancellationToken);

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        => await _entitySet.Where(expression).ToListAsync(cancellationToken);
}