using Microsoft.AspNetCore.Mvc;
using YandexLegendMusicKiller.Data.Repositories.Albums;

namespace YandexLegendMusicKiller.UI.Controllers;

public class AlbumsController : Controller
{
    private readonly IAlbumsRepository _albumsRepository;

    public AlbumsController(IAlbumsRepository albumsRepository)
    {
        _albumsRepository = albumsRepository;
    }

    [HttpGet]
    public async Task<ViewResult> Index(CancellationToken cancellationToken)
    {
        var albums = await _albumsRepository.GetAllAsync(cancellationToken);
        return View(albums);
    }
}