using System.Linq.Expressions;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Albums;

public interface IAlbumsRepository : IGenericRepository<Album>
{
    Task<IEnumerable<Album>> GetAllAlbumsWithAuthorsAsync(Expression<Func<Album, bool>> expression, CancellationToken ct = default);
    IQueryable<Album> GetAllAlbumsWithAuthors();
}