using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Common;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly YandexLegendMusicKillerDbContext DbContext;
    protected readonly DbSet<TEntity> EntitySet;

    internal GenericRepository(YandexLegendMusicKillerDbContext dbContext)
    {
        DbContext = dbContext;
        EntitySet = DbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await EntitySet.AddAsync(entity, cancellationToken);

    public void Update(TEntity entity) 
        => EntitySet.Update(entity);

    public void Remove(TEntity entity) 
        => EntitySet.Remove(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        => await EntitySet.Where(expression).ToListAsync(cancellationToken);
}