using System.Linq.Expressions;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Songs;

public interface ISongsRepository : IGenericRepository<Song>
{
    Task<IEnumerable<Song>> GetAllSongsWithAlbumsAndGenresAsync(CancellationToken ct = default);
    Task<IEnumerable<Song>> GetAllSongsWithAlbumsAndGenresAsync(Expression<Func<Song, bool>> expression, CancellationToken ct = default);
}