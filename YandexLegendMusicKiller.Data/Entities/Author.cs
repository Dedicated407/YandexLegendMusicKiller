using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - Артист
/// </summary>
public class Author : BaseGuidEntity
{
    public string NickName { get; set; } = null!;

    public string? FullName { get; set; }
}