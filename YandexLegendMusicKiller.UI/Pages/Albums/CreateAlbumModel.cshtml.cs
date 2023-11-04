using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Albums;

namespace YandexLegendMusicKiller.UI.Pages.Albums;

public class CreateAlbumModel : PageModel
{
    private readonly IAlbumsRepository _albumsRepository;

    [BindProperty]
    public Album Album { get; set; } = new();

    public CreateAlbumModel(IAlbumsRepository albumsRepository)
    {
        _albumsRepository = albumsRepository;
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        await _albumsRepository.AddAsync(Album, ct);
        return RedirectToPage("Index");
    }
}