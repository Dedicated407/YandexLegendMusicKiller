using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Albums;

public sealed class AlbumsRepository : GenericRepository<Album>, IAlbumsRepository
{
    public AlbumsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }
}