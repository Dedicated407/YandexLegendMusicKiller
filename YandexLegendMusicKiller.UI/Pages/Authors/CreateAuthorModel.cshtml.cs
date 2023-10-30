﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YandexLegendMusicKiller.Data.Entities;
using YandexLegendMusicKiller.Data.Repositories.Authors;

namespace YandexLegendMusicKiller.UI.Pages.Authors;

public class CreateAuthorModel : PageModel
{
    private readonly IAuthorsRepository _authorsRepository;

    [BindProperty]
    public Author Author { get; set; } = new();

    public CreateAuthorModel(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        await _authorsRepository.AddAsync(Author, cancellationToken);
        return RedirectToPage("Index");
    }
}