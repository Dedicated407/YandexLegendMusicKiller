using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Albums;

namespace YandexLegendMusicKiller.UI.Pages.Albums;

public sealed class AlbumsModel : PageModel
{
    private readonly IAlbumsRepository _albumsRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<Album>? Albums { get; private set; }

    public AlbumsModel(IAlbumsRepository albumsRepository)
    {
        _albumsRepository = albumsRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            Albums = await _albumsRepository.GetAllAlbumsWithAuthorsAsync(x => 
                    x.Name.Contains(SearchString) || 
                    x.Author.NickName.Contains(SearchString) || 
                    x.Author.FullName!.Contains(SearchString), 
                ct);
        }
        else
        {
            Albums = await _albumsRepository.GetAllAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken ct)
    {
        var author = await _albumsRepository.GetAsync(x => x.Id == id, ct);
        if (author != null)
        {
            _albumsRepository.Remove(author);
        }

        return RedirectToPage();
    }
}