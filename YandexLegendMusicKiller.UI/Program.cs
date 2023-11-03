using YandexLegendMusicKiller.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// добавляем в приложение сервисы Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.AddRepositories();
builder.AddDatabase();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePages();

// добавляем поддержку маршрутизации для Razor Pages
app.MapRazorPages();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.Run();