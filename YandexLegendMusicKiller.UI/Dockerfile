FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YandexLegendMusicKiller.UI/YandexLegendMusicKiller.UI.csproj", "YandexLegendMusicKiller.UI/"]
RUN dotnet restore "YandexLegendMusicKiller.UI/YandexLegendMusicKiller.UI.csproj"
COPY . .
WORKDIR "/src/YandexLegendMusicKiller.UI"
RUN dotnet build "YandexLegendMusicKiller.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YandexLegendMusicKiller.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YandexLegendMusicKiller.UI.dll"]
