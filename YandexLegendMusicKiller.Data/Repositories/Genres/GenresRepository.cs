using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Genres;

public sealed class GenresRepository : GenericRepository<Genre>, IGenresRepository
{
    public GenresRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }
}