using CréditImmobilier.Interfaces;
using CréditImmobilier.Services;
using Microsoft.Extensions.Logging;

namespace CréditImmobilier;

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

        builder.Services.AddSingleton<ILoanStatisticsService, LoanStatisticsService>();
        builder.Services.AddSingleton<ILoanCriteriaValidator, LoanCriteriaService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}