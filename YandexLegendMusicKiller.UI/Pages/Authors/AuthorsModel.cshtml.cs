using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

internal sealed class AuthorsModel : PageModel
{
    private readonly IAuthorsRepository _authorsRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<Author>? Authors { get; private set; }

    public AuthorsModel(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            Authors = await _authorsRepository.GetAllAsync(x => 
                    x.NickName.Contains(SearchString) || x.FullName!.Contains(SearchString), 
                ct);
        }
        else
        {
            Authors = await _authorsRepository.GetAllAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken ct)
    {
        var author = await _authorsRepository.GetAsync(x => x.Id == id, ct);
        if (author != null)
        {
            _authorsRepository.Remove(author);
        }

        return RedirectToPage();
    }
}