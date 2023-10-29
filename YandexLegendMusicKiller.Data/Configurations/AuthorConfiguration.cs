using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YandexLegendMusicKiller.Data.Configurations.Common;
using YandexLegendMusicKiller.Data.Entities;

namespace YandexLegendMusicKiller.Data.Configurations;

internal sealed class AuthorConfiguration : BaseGuidEntityConfiguration<Author>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Author> builder)
    {
        base.ConfigureProperties(builder);

        builder.ToTable(Tables.Authors);

        builder.Property(e => e.NickName).HasColumnName("nick_name").HasMaxLength(80).IsRequired();
        builder.Property(e => e.FullName).HasColumnName("full_name").HasMaxLength(255);
    }
}