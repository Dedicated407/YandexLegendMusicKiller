using System.Linq.Expressions;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.MusicCollections;

public interface IMusicCollectionsRepository : IGenericRepository<MusicCollection>
{
    Task<IEnumerable<MusicCollection>> GetAllMusicCollectionsWithSongsAsync(CancellationToken ct = default);
    Task<IEnumerable<MusicCollection>> GetAllMusicCollectionsWithSongsAsync(Expression<Func<MusicCollection, bool>> expression, CancellationToken ct = default);
}