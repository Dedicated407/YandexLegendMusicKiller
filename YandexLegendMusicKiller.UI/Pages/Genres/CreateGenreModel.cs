using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Genres;

namespace YandexLegendMusicKiller.UI.Pages.Genres;

public class CreateGenreModel : PageModel
{
    private readonly IGenresRepository _genresRepository;

    [BindProperty]
    public Genre Genre { get; set; } = new();

    public CreateGenreModel(IGenresRepository genresRepository)
    {
        _genresRepository = genresRepository;
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        await _genresRepository.AddAsync(Genre, cancellationToken);
        return RedirectToPage("Index");
    }
}