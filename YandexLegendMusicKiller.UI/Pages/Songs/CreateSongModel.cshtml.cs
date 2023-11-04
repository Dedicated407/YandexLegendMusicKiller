using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Albums;
using YandexLegendMusicKiller.Data.Repositories.Genres;
using YandexLegendMusicKiller.Data.Repositories.Songs;

namespace YandexLegendMusicKiller.UI.Pages.Songs;

public class CreateSongModel : PageModel
{
    private readonly ISongsRepository _songsRepository;
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IGenresRepository _genresRepository;

    [BindProperty]
    public Song Song { get; set; } = new();

    [BindProperty]
    public Guid AlbumId { get; set; }

    [BindProperty]
    public string GenreId { get; set; } = null!;

    public List<SelectListItem>? Albums { get; private set; }

    public List<SelectListItem>? Genres { get; private set; }

    public CreateSongModel(ISongsRepository songsRepository, IAlbumsRepository albumsRepository, 
        IGenresRepository genresRepository)
    {
        _songsRepository = songsRepository;
        _albumsRepository = albumsRepository;
        _genresRepository = genresRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        var albumsData = await _albumsRepository.GetAllAlbumsWithAuthorsAsync(ct);
        Albums = albumsData.Select(x => new SelectListItem 
        {
            Value = x.Id.ToString(),
            Text = $"Альбом: {x.Name} Исполнитель: {x.Author.NickName}"
        }).ToList();

        var genresData = await _genresRepository.GetAllAsync(ct);
        Genres = genresData.Select(x => new SelectListItem
        {
            Value = x.Name,
            Text = x.Name
        }).ToList();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Song.AlbumId = AlbumId;
        Song.GenreId = GenreId;
        await _songsRepository.AddAsync(Song, ct);
        return RedirectToPage("Index");
    }
}