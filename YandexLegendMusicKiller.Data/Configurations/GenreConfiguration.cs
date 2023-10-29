using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Configurations.Common;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data.Configurations;

internal sealed class GenreConfiguration : BaseEntityConfiguration<Genre>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable(Tables.Genres);

        builder.HasKey(e => e.Name).HasName($"{Tables.Genres}_pkey");
        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
    }
}