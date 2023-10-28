using YandexLegendMusicKiller.Data.Repositories.Songs;

namespace YandexLegendMusicKiller.UI.Extensions;

public static class RepositoryExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISongsRepository, SongsRepository>();
    }
}