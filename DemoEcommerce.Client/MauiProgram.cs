using DemoEcommerce.Client.ViewModels;
using DemoEcommerce.Client.Views.Desktop;
using Microsoft.Extensions.Logging;

namespace DemoEcommerce.Client
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

            builder.Services.AddSingleton<DesktopHomePageViewModel>();
            builder.Services.AddSingleton<DesktopHomePage>();

            builder.Services.AddSingleton<AddProductPageViewModel>();
            builder.Services.AddSingleton<AddProductPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
