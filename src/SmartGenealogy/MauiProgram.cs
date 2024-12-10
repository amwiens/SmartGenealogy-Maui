using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SmartGenealogy.Data;
using SmartGenealogy.Data.Repository;
using SmartGenealogy.ViewModels;
using SmartGenealogy.Views;

namespace SmartGenealogy;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddDbContext<SmartGenealogyDbContext>();
        builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();

        builder.Services.AddTransient<MainPage>();

        builder.Services.AddScoped<MainViewModel>();

        return builder.Build();
    }

    public static void SwitchDatabase(string newDatabasePath)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SmartGenealogyDbContext>();
        optionsBuilder.UseSqlite($"Data Source={newDatabasePath}");
    }
}