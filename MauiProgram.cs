using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SurveysApp.Services;
using SurveysApp.Services.Interfaces;

namespace SurveysApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Views.LoginPage>();
        builder.Services.AddSingleton<Views.SurveyPage>();

        builder.Services.AddSingleton<ViewModels.LoginPageViewModel>();
        builder.Services.AddSingleton<ViewModels.SurveyPageViewModel>();

        builder.Services.AddSingleton<ISurveyService,SurveyService>();

        return builder.Build();
    }
}
