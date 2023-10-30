using Microsoft.AspNetCore.Mvc;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorsRepository _authorsRepository;

    public AuthorsController(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    // [HttpGet]
    // public async Task<ViewResult> Index() => 
    //     await Task.Run(() => View(_authorsRepository));

    [HttpGet]
    public async Task<ViewResult> Index(CancellationToken cancellationToken)
    {
        var authors = await _authorsRepository.GetAllAsync(cancellationToken);
        return View(authors);
    }

    [HttpGet("all")]
    public async Task<IEnumerable<Author>> GetAll(CancellationToken cancellationToken)
    {
        return await _authorsRepository.GetAllAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        await _authorsRepository.AddAsync(author);
        return RedirectToAction("Index", "Authors");
    }
}