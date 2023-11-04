using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Songs;

public sealed class SongsRepository : GenericRepository<Song>, ISongsRepository
{
    public SongsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Song>> GetAllSongsWithAlbumsAndGenresAsync(CancellationToken ct = default)
        => await EntitySet.Include(x => x.Album)
            .Include(x => x.Genre)
            .ToListAsync(ct);

    public async Task<IEnumerable<Song>> GetAllSongsWithAlbumsAndGenresAsync(Expression<Func<Song, bool>> expression, 
        CancellationToken ct = default)
        => await EntitySet.Include(x => x.Album)
            .Include(x => x.Genre)
            .Where(expression)
            .ToListAsync(ct);
}