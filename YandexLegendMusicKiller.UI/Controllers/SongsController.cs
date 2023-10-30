using Microsoft.AspNetCore.Mvc;
using YandexLegendMusicKiller.Data.Repositories.Songs;

namespace YandexLegendMusicKiller.UI.Controllers;

public class SongsController : Controller
{
    private readonly ISongsRepository _songsRepository;

    public SongsController(ISongsRepository songsRepository)
    {
        _songsRepository = songsRepository;
    }

    [HttpGet]
    public async Task<ViewResult> Index(CancellationToken cancellationToken)
    {
        var songs = await _songsRepository.GetAllAsync(cancellationToken);
        return View(songs);
    }
}