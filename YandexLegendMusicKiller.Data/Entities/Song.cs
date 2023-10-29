using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - песня
/// </summary>
public class Song : BaseGuidEntity
{
    public string Name { get; set; } = null!;

    public Guid AlbumId { get; set; }
    public Album Album { get; set; } = null!;

    public string GenreId { get; set; } = null!;
    public Genre Genre { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public ICollection<MusicCollection> MusicCollections { get; } = new List<MusicCollection>();
}