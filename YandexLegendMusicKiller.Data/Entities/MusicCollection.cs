using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - сборник
/// В сборниках содержатся треки разных артистов,
/// возможно, разных жанров.
/// </summary>
public class MusicCollection : BaseGuidEntity
{
    public string Name { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public ICollection<Song> Songs { get; } = new List<Song>();
}