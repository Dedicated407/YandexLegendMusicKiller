using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

public class AuthorModel : PageModel
{
    private readonly IAuthorsRepository _dataRepository;

    public IEnumerable<Author>? Authors { get; set; }

    public AuthorModel(IAuthorsRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public async Task OnGet()
    {
        Authors = await _dataRepository.GetAllAsync();
    }
}