using Microsoft.AspNetCore.Mvc;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;
using YandexLegendMusicKiller.UI.Pages.Authors;

namespace YandexLegendMusicKiller.UI.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorsRepository _authorsRepository;

    public AuthorsController(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    [HttpGet]
    public async Task<ViewResult> Index() 
        => await Task.Run(() => View(new AuthorModel(_authorsRepository)));

    [HttpPost]
    public async Task<IActionResult> Create(Author author, CancellationToken cancellationToken)
    {
        await _authorsRepository.AddAsync(author, cancellationToken);
        return RedirectToAction("Index");
    }
}