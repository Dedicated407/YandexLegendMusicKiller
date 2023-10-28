namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - сборник
/// В сборниках содержатся треки разных артистов,
/// возможно, разных жанров.
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="Name">Наименование коллекции</param>
public record MusicCollection(Guid Id, string Name);