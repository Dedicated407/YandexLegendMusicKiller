using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Songs;

namespace YandexLegendMusicKiller.UI.Pages.Songs;

internal sealed class SongsModel : PageModel
{
    private readonly ISongsRepository _songsRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<Song>? Songs { get; private set; }

    public SongsModel(ISongsRepository songsRepository)
    {
        _songsRepository = songsRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            Songs = await _songsRepository.GetAllSongsWithAlbumsAndGenresAsync(x => 
                    x.Name.Contains(SearchString),
                ct);
        }
        else
        {
            Songs = await _songsRepository.GetAllSongsWithAlbumsAndGenresAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken ct)
    {
        var song = await _songsRepository.GetAsync(x => x.Id == id, ct);
        if (song != null)
        {
            _songsRepository.Remove(song);
        }

        return RedirectToPage();
    }
}