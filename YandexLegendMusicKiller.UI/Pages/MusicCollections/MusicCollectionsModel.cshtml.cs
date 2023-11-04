using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.MusicCollections;

namespace YandexLegendMusicKiller.UI.Pages.MusicCollections;

internal sealed class MusicCollectionsModel : PageModel
{
    private readonly IMusicCollectionsRepository _musicCollectionsRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<MusicCollection>? MusicCollections { get; private set; }

    public IEnumerable<Song>? Songs { get; private set; }

    public MusicCollectionsModel(IMusicCollectionsRepository musicCollectionsRepository)
    {
        _musicCollectionsRepository = musicCollectionsRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            MusicCollections = await _musicCollectionsRepository.GetAllMusicCollectionsWithSongsAsync(x => 
                    x.Name.Contains(SearchString),
                ct);
        }
        else
        {
            MusicCollections = await _musicCollectionsRepository.GetAllMusicCollectionsWithSongsAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken ct)
    {
        var musicCollection = await _musicCollectionsRepository.GetAsync(x => x.Id == id, ct);
        if (musicCollection != null)
        {
            _musicCollectionsRepository.Remove(musicCollection);
        }

        return RedirectToPage();
    }
}