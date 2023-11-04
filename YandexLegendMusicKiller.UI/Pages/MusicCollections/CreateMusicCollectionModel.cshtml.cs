using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.MusicCollections;

namespace YandexLegendMusicKiller.UI.Pages.MusicCollections;

internal sealed class CreateMusicCollectionModel : PageModel
{
    private readonly IMusicCollectionsRepository _musicCollectionsRepository;

    [BindProperty]
    public MusicCollection MusicCollection { get; set; } = new();

    public CreateMusicCollectionModel(IMusicCollectionsRepository musicCollectionsRepository)
    {
        _musicCollectionsRepository = musicCollectionsRepository;
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        await _musicCollectionsRepository.AddAsync(MusicCollection, ct);
        return RedirectToPage("Index");
    }
}