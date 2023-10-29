using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Configurations.Common;

internal abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureProperties(builder);
    }

    protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}