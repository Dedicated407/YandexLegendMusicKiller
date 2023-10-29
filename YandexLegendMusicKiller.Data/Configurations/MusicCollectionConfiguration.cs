using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Configurations.Common;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data.Configurations;

internal sealed class MusicCollectionConfiguration : BaseGuidEntityConfiguration<MusicCollection>
{
    protected override void ConfigureProperties(EntityTypeBuilder<MusicCollection> builder)
    {
        base.ConfigureProperties(builder);

        builder.ToTable(Tables.MusicCollections);

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(80).IsRequired();
    }
}