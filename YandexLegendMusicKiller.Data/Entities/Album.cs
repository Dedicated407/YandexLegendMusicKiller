using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - Альбом
/// </summary>
public class Album : BaseGuidEntity
{
    public string Name { get; set; } = null!;

    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}