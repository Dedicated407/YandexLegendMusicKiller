namespace YandexLegendMusicKiller.Data.Entities.Common;

public class BaseGuidEntity : BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}