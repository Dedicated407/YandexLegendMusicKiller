using Microsoft.AspNetCore.Mvc;

namespace YandexLegendMusicKiller.UI.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
        => View();
}