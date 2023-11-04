using System.Linq.Expressions;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Albums;

public interface IAlbumsRepository : IGenericRepository<Album>
{
    IQueryable<Album> GetAllAlbumsWithAuthors();

    Task<IEnumerable<Album>> GetAllAlbumsWithAuthorsAsync(CancellationToken ct = default);
    Task<IEnumerable<Album>> GetAllAlbumsWithAuthorsAsync(Expression<Func<Album, bool>> expression, CancellationToken ct = default);
}