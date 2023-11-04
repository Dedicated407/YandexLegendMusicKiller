using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Genres;

namespace YandexLegendMusicKiller.UI.Pages.Genres;

internal sealed class GenresModel : PageModel
{
    private readonly IGenresRepository _genreRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<Genre>? Genres { get; private set; }

    public GenresModel(IGenresRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            Genres = await _genreRepository.GetAllAsync(x => x.Name.Contains(SearchString), ct);
        }
        else
        {
            Genres = await _genreRepository.GetAllAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(string name, CancellationToken ct)
    {
        var genre = await _genreRepository.GetAsync(x => x.Name == name, ct);
        if (genre != null)
        {
            _genreRepository.Remove(genre);
        }

        return RedirectToPage();
    }
}