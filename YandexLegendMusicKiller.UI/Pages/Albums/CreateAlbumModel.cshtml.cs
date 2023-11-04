using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Albums;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Albums;

public class CreateAlbumModel : PageModel
{
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IAuthorsRepository _authorsRepository;

    [BindProperty]
    public Album Album { get; set; } = new();

    [BindProperty]
    public Guid AuthorId { get; set; }

    public List<SelectListItem>? Authors { get; private set; }

    public CreateAlbumModel(IAlbumsRepository albumsRepository, IAuthorsRepository authorsRepository)
    {
        _albumsRepository = albumsRepository;
        _authorsRepository = authorsRepository;
    }

    public async Task OnGet(CancellationToken ct)
    {
        var authorsData = await _authorsRepository.GetAllAsync(ct);

        Authors = authorsData.Select(x => new SelectListItem 
        {
            Value = x.Id.ToString(),
            Text = x.NickName
        }).ToList();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Album.AuthorId = AuthorId;
        await _albumsRepository.AddAsync(Album, ct);
        return RedirectToPage("Index");
    }
}