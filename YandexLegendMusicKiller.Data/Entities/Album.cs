namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - Альбом
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="Name">Наименование альбома</param>
/// <param name="Songs">Коллекция песен</param>
public record Album(Guid Id, string Name, ICollection<Song> Songs);