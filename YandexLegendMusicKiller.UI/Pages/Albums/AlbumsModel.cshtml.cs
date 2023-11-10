using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Albums;

namespace YandexLegendMusicKiller.UI.Pages.Albums;

internal sealed class AlbumsModel : PageModel
{
    private readonly IAlbumsRepository _albumsRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchOption { get; set; }

    public IEnumerable<Album>? Albums { get; private set; }

    public AlbumsModel(IAlbumsRepository albumsRepository)
    {
        _albumsRepository = albumsRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            SearchString = SearchString!.ToLower();
            Albums = SearchOption!.ToLower() switch
            {
                "author" => await _albumsRepository.GetAllAlbumsWithAuthorsAsync(x => x.Author.NickName.ToLower().Contains(SearchString), ct),
                _ => await _albumsRepository.GetAllAlbumsWithAuthorsAsync(x => x.Name.ToLower().Contains(SearchString), ct)
            };
        }
        else
        {
            Albums = await _albumsRepository.GetAllAlbumsWithAuthorsAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken ct)
    {
        var album = await _albumsRepository.GetAsync(x => x.Id == id, ct);
        if (album != null)
        {
            _albumsRepository.Remove(album);
        }

        return RedirectToPage();
    }
}