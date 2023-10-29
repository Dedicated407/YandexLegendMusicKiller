using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Configurations.Common;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data.Configurations;

internal sealed class SongConfiguration : BaseGuidEntityConfiguration<Song>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Song> builder)
    {
        base.ConfigureProperties(builder);

        builder.ToTable(Tables.Songs);

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(80).IsRequired();
        builder.Property(e => e.AlbumId).HasColumnName($"{Tables.Albums}_id").IsRequired();
        builder.Property(e => e.GenreId).HasColumnName($"{Tables.Genres}_id").IsRequired();
    }
}