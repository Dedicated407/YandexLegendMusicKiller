using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data.Configurations;

public class MusicCollectionConfiguration : IEntityTypeConfiguration<MusicCollection>
{
    public void Configure(EntityTypeBuilder<MusicCollection> builder)
    {
        throw new NotImplementedException();
    }
}