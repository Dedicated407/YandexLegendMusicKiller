using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Configurations.Common;

internal abstract class BaseGuidEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : BaseGuidEntity
{
    protected override void ConfigureProperties(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedNever().IsRequired();
    }
}