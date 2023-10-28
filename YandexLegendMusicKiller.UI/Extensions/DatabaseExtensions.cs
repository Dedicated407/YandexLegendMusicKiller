using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data;

namespace YandexLegendMusicKiller.UI.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Connection string is missing.");
        }

        builder.Services.AddDbContext<YandexLegendMusicKillerDbContext>(options => options.UseNpgsql(connectionString));
    }
}