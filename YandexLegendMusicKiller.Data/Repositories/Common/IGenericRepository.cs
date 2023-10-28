using System.Linq.Expressions;
using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Common;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
}