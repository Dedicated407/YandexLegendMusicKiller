using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Authors;

public sealed class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
{
    public AuthorsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }
}