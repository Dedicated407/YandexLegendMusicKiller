using Microsoft.EntityFrameworkCore;
using YandexLegendMusicKiller.Data.Configurations;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data;

public sealed class YandexLegendMusicKillerDbContext : DbContext
{
    #region DbSets

    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<MusicCollection> MusicCollections { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;

    #endregion

    public YandexLegendMusicKillerDbContext()
    {
    }

    public YandexLegendMusicKillerDbContext(DbContextOptions<YandexLegendMusicKillerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AlbumConfiguration().Configure(modelBuilder.Entity<Album>());
        new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
        new GenreConfiguration().Configure(modelBuilder.Entity<Genre>());
        new MusicCollectionConfiguration().Configure(modelBuilder.Entity<MusicCollection>());
        new SongConfiguration().Configure(modelBuilder.Entity<Song>());
    }
}