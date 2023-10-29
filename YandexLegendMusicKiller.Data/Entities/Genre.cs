using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - жанр
/// </summary>
public class Genre : BaseEntity
{
    public string Name { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public ICollection<Song> Songs = new List<Song>();
};