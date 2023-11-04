using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

internal sealed class UpdateAuthorModel : PageModel
{
    private readonly IAuthorsRepository _authorsRepository;

    [BindProperty]
    public Author? Author { get; set; }

    public UpdateAuthorModel(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<IActionResult> OnGetAsync(Guid id, CancellationToken ct)
    {
        Author = await _authorsRepository.GetAsync(x => x.Id == id, ct);

        if (Author == null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPostAsync(CancellationToken cancellationToken)
    {
        _authorsRepository.Update(Author!);
        return RedirectToPage("Index");
    }
}