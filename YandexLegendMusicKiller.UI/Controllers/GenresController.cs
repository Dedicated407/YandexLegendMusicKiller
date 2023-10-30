using Microsoft.AspNetCore.Mvc;
using YandexLegendMusicKiller.Data.Repositories.Genres;

namespace YandexLegendMusicKiller.UI.Controllers;

public class GenresController : Controller
{
    private readonly IGenresRepository _genresRepository;

    public GenresController(IGenresRepository genresRepository)
    {
        _genresRepository = genresRepository;
    }

    [HttpGet]
    public async Task<ViewResult> Index(CancellationToken cancellationToken)
    {
        var genres = await _genresRepository.GetAllAsync(cancellationToken);
        return View(genres);
    }
}