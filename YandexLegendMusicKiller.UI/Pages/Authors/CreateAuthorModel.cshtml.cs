using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

internal sealed class CreateAuthorModel : PageModel
{
    private readonly IAuthorsRepository _authorsRepository;

    [BindProperty]
    public Author Author { get; set; } = new();

    public CreateAuthorModel(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        await _authorsRepository.AddAsync(Author, ct);
        return RedirectToPage("Index");
    }
}