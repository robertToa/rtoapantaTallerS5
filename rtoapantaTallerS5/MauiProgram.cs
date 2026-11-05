using Microsoft.Extensions.Logging;
using rtoapantaTallerS5.Repositories;
using rtoapantaTallerS5.Utils;

namespace rtoapantaTallerS5
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

            string dbPath = FileAccessHelper.GetLocalFilePath("db_uisrael.db");
            builder.Services
                .AddSingleton<PersonRepostory>(s => ActivatorUtilities.CreateInstance<PersonRepostory>(s, dbPath));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
