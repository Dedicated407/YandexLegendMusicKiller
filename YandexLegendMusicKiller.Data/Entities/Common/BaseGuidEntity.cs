using System.Text.Json.Serialization;

namespace YandexLegendMusicKiller.Data.Entities.Common;

public class BaseGuidEntity : BaseEntity
{
    [JsonIgnore]
    public Guid Id { get; init; } = Guid.NewGuid();
}