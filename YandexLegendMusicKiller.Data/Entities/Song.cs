using YandexLegendMusicKiller.Data.Entities.Common;

namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - песня
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="Name">Название песни</param>
/// <param name="GenreId">Жанр</param>
public record Song(Guid Id, string Name, string GenreId) : BaseEntity(Id);