using Microsoft.Extensions.Logging;
using System.Globalization;

namespace MySecondMAUIApp
{
    public static class MauiProgram
    {
        static MauiProgram() {
            var customCulture = CultureInfo.InvariantCulture;

            // Устанавливаем её по умолчанию для всех новых потоков в приложении
            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;

            // Теперь текущий поток тоже переключаем на эту культуру
            Thread.CurrentThread.CurrentCulture = customCulture;
            Thread.CurrentThread.CurrentUICulture = customCulture;
        }

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

            return builder.Build();
        }
    }
}
