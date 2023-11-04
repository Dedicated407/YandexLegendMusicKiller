using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

internal sealed class AuthorsModel : PageModel
{
    private readonly IAuthorsRepository _authorRepository;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public IEnumerable<Author>? Authors { get; private set; }

    public AuthorsModel(IAuthorsRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            Authors = await _authorRepository.GetAllAsync(x => 
                    x.NickName.Contains(SearchString) || x.FullName!.Contains(SearchString), 
                ct);
        }
        else
        {
            Authors = await _authorRepository.GetAllAsync(ct);
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken ct)
    {
        var author = await _authorRepository.GetAsync(x => x.Id == id, ct);
        if (author != null)
        {
            _authorRepository.Remove(author);
        }

        return RedirectToPage();
    }
}