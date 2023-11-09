using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.MusicCollections;
using YandexLegendMusicKiller.Data.Repositories.Songs;

namespace YandexLegendMusicKiller.UI.Pages.MusicCollections;

internal sealed class UpdateMusicCollectionItemsModel : PageModel
{
    private readonly IMusicCollectionsRepository _musicCollectionsRepository;
    private readonly ISongsRepository _songsRepository;

    [BindProperty]
    public MusicCollection? MusicCollection { get; set; }

    [BindProperty]
    public Guid[]? SongToAddIds { get; set; }

    public List<SelectListItem>? Songs { get; private set; }

    public UpdateMusicCollectionItemsModel(IMusicCollectionsRepository musicCollectionsRepository, 
        ISongsRepository songsRepository)
    {
        _musicCollectionsRepository = musicCollectionsRepository;
        _songsRepository = songsRepository;
    }

    public async Task<IActionResult> OnGetAsync(Guid id, CancellationToken ct)
    {
        MusicCollection = await _musicCollectionsRepository.GetMusicCollectionWithSongsAsync(x => 
                x.Id == id, 
            ct);

        if (MusicCollection == null)
        {
            return NotFound();
        }

        var songs = await _songsRepository.GetAllSongsWithAlbumsAndGenresAsync(ct);

        var newList = new List<SelectListItem>();
        
        foreach (var song in songs)
        {
            if (!MusicCollection.Songs.Contains(song))
            {
                newList.Add(new SelectListItem
                {
                    Value = song.Id.ToString(),
                    Text = $"Композиция: {song.Name} Альбом: {song.Album.Name}"
                });
            }
        }

        Songs = newList;

        // TODO: реализовать получше через LINQ
        // Songs = songs
        //     .Where(song => !MusicCollection.Songs.Any(x => x.Id == song.Id))
        //     .Select(x => new SelectListItem 
        //     { 
        //         Value = x.Id.ToString(), 
        //         Text = $"Композиция: {x.Name} Альбом: {x.Album.Name}" 
        //     }).ToList();

        return Page();
    }

    public async Task<IActionResult> OnPostEdit(CancellationToken ct)
    {
        MusicCollection = await _musicCollectionsRepository.GetMusicCollectionWithSongsAsync(x => 
                x.Id == MusicCollection!.Id, 
            ct);
        foreach (var songToAddId in SongToAddIds!)
        {
            var songToAdd = await _songsRepository.GetAsync(x => x.Id == songToAddId, ct);
            if (songToAdd != null)
            {
                MusicCollection?.Songs.Add(songToAdd);
            }
        }
        _musicCollectionsRepository.Update(MusicCollection!);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDelete(Guid songId, CancellationToken ct)
    {
        MusicCollection = await _musicCollectionsRepository.GetMusicCollectionWithSongsAsync(x => 
                x.Id == MusicCollection!.Id, 
            ct);
        var songToRemove = MusicCollection?.Songs.FirstOrDefault(s => s.Id == songId);
        if (songToRemove != null)
        {
            MusicCollection?.Songs.Remove(songToRemove);
        }
        _musicCollectionsRepository.Update(MusicCollection!);

        return RedirectToPage();
    }
}