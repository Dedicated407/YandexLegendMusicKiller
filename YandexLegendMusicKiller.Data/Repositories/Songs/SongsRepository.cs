using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Songs;

public class SongsRepository : GenericRepository<Song>, ISongsRepository
{
    internal SongsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }
}