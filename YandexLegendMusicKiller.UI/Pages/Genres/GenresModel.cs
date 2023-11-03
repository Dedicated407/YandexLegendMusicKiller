using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Genres;

namespace YandexLegendMusicKiller.UI.Pages.Genres;

public class GenresModel : PageModel
{
    private readonly IGenresRepository _genreRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<Genre>? Genres { get; private set; }

    public GenresModel(IGenresRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task OnGet()
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            Genres = await _genreRepository.GetAllAsync(x => x.Name.Contains(SearchString));
        }
        else
        {
            Genres = await _genreRepository.GetAllAsync();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(string name)
    {
        var genre = await _genreRepository.GetAsync(x => x.Name == name);
        if (genre != null)
        {
            _genreRepository.Remove(genre);
        }

        return RedirectToPage();
    }
}