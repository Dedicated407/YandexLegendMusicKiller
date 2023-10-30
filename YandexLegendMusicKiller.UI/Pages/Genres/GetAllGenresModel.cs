using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Genres;

namespace YandexLegendMusicKiller.UI.Pages.Genres;

public class GetAllGenresModel : PageModel
{
    private readonly IGenresRepository _genreRepository;

    public IEnumerable<Genre>? Genres { get; set; }

    public GetAllGenresModel(IGenresRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task OnGet()
    {
        Genres = await _genreRepository.GetAllAsync();
    }
}