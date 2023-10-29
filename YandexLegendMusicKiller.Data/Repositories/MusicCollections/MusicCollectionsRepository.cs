using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.MusicCollections;

public class MusicCollectionsRepository : GenericRepository<MusicCollection>, IMusicCollectionsRepository
{
    public MusicCollectionsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }
}