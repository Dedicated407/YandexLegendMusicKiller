namespace YandexLegendMusicKiller.Data.Entities;

/// <summary>
/// Сущность - Артист
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="NickName">Псевдоним</param>
/// <param name="FullName">Полное ФИО</param>
public record Author(Guid Id, string NickName, string? FullName);