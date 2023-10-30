using Microsoft.AspNetCore.Mvc;
using YandexLegendMusicKiller.Data.Repositories.MusicCollections;

namespace YandexLegendMusicKiller.UI.Controllers;

public class MusicCollectionsController : Controller
{
    private readonly IMusicCollectionsRepository _musicCollectionsRepository;

    public MusicCollectionsController(IMusicCollectionsRepository musicCollectionsRepository)
    {
        _musicCollectionsRepository = musicCollectionsRepository;
    }

    [HttpGet]
    public async Task<ViewResult> Index(CancellationToken cancellationToken)
    {
        var musicCollections = await _musicCollectionsRepository.GetAllAsync(cancellationToken);
        return View(musicCollections);
    }
}