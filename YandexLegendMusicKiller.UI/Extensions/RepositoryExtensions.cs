using YandexLegendMusicKiller.Data.Repositories.Albums;
using YandexLegendMusicKiller.Data.Repositories.Authors;
using YandexLegendMusicKiller.Data.Repositories.Genres;
using YandexLegendMusicKiller.Data.Repositories.MusicCollections;
using YandexLegendMusicKiller.Data.Repositories.Songs;

namespace YandexLegendMusicKiller.UI.Extensions;

public static class RepositoryExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAlbumsRepository, AlbumsRepository>();
        builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
        builder.Services.AddScoped<IGenresRepository, GenresRepository>();
        builder.Services.AddScoped<IMusicCollectionsRepository, MusicCollectionsRepository>();
        builder.Services.AddScoped<ISongsRepository, SongsRepository>();
    }
}