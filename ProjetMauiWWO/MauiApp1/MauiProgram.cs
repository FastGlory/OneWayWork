using MauiApp1.Service;
using MauiApp1.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MauiApp1
{
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
            builder.Services.AddSingleton<LocalDbService>();
            builder.Services.AddTransient<Stagiaire_Page>();
            builder.Services.AddTransient<Stage_Page>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            Task.Run(async () =>
            {
                await InitializeDatabaseAsync(app.Services);
            }).Wait();
            // On initialise la database avant d'ouvrire l'applicaiton

            return app;
        }

        private static async Task InitializeDatabaseAsync(IServiceProvider services)
        {
            var dbService = services.GetRequiredService<LocalDbService>();
            await dbService.InitializeDatabaseAsync();
        }
    }
}
