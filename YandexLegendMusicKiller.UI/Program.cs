using Microsoft.OpenApi.Models;
using YandexLegendMusicKiller.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// добавляем в приложение сервисы Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.AddRepositories();
builder.AddDatabase();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
else
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