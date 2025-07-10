using MaquisKExamP3ControlEquiElectro.Data;
using MaquisKExamP3ControlEquiElectro.Views;
using Microsoft.Extensions.Logging;

namespace MaquisKExamP3ControlEquiElectro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "equipos.db");

            builder.Services.AddSingleton<AppDatabase>(s => new AppDatabase(dbPath));

            builder.Services.AddSingleton<RegistroPage>();
            builder.Services.AddSingleton<ListaPage>();
            builder.Services.AddSingleton<LogsPage>();

            builder.Services.AddSingleton<AppShell>();

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

            return builder.Build();
        }
    }
}
