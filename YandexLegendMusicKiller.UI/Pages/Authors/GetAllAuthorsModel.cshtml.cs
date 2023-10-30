using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

public class GetAllAuthorsModel : PageModel
{
    private readonly IAuthorsRepository _authorRepository;

    public IEnumerable<Author>? Authors { get; set; }

    public GetAllAuthorsModel(IAuthorsRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task OnGet()
    {
        Authors = await _authorRepository.GetAllAsync();
    }
}