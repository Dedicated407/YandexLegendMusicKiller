using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.MusicCollections;

public class MusicCollectionsRepository : GenericRepository<MusicCollection>, IMusicCollectionsRepository
{
    public MusicCollectionsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<MusicCollection>> GetAllMusicCollectionsWithSongsAsync(CancellationToken ct = default)
        => await EntitySet
            .Include(x => x.Songs)
            .ToListAsync(ct);

    public async Task<IEnumerable<MusicCollection>> GetAllMusicCollectionsWithSongsAsync(Expression<Func<MusicCollection, bool>> expression, CancellationToken ct = default)
        => await EntitySet
            .Include(x => x.Songs)
            .Where(expression)
            .ToListAsync(ct);
}