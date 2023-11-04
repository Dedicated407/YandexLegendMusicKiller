using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Common;

namespace YandexLegendMusicKiller.Data.Repositories.Albums;

public sealed class AlbumsRepository : GenericRepository<Album>, IAlbumsRepository
{
    public AlbumsRepository(YandexLegendMusicKillerDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Album> GetAllAlbumsWithAuthors() =>
        EntitySet.Include(x => x.Author)
            .AsQueryable();

    public async Task<IEnumerable<Album>> GetAllAlbumsWithAuthorsAsync(CancellationToken ct = default)
        => await EntitySet.Include(x => x.Author).ToListAsync(ct);

    public async Task<IEnumerable<Album>> GetAllAlbumsWithAuthorsAsync(Expression<Func<Album, bool>> expression, 
        CancellationToken ct = default) 
        => await EntitySet.Include(x => x.Author)
            .Where(expression)
            .ToListAsync(ct);
}