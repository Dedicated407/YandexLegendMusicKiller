using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Genres;

namespace YandexLegendMusicKiller.UI.Pages.Genres;

public class GetAllGenresModel : PageModel
{
    private readonly IGenresRepository _genreRepository;

    public IEnumerable<Genre>? Genres { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public GetAllGenresModel(IGenresRepository genreRepository)
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
}