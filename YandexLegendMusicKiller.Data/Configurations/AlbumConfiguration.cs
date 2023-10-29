using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Configurations.Common;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data.Configurations;

internal sealed class AlbumConfiguration : BaseGuidEntityConfiguration<Album>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Album> builder)
    {
        base.ConfigureProperties(builder);

        builder.ToTable(Tables.Albums);

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(80).IsRequired();
        builder.Property(e => e.AuthorId).HasColumnName($"{Tables.Authors}_id").IsRequired();
    }
}