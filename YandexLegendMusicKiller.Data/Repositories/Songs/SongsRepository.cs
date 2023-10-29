using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Songs;

public sealed class SongsRepository : GenericRepository<Song>, ISongsRepository
{
    public SongsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }
}