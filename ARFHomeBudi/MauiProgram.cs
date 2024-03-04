using ARFHomeBudi.Pages;
using ARFHomeBudi.Services;
using Microsoft.Extensions.Logging;

namespace ARFHomeBudi
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

            builder.Services.AddSingleton<UserDBService>();
            builder.Services.AddSingleton<CategoryDBService>();
            builder.Services.AddSingleton<JobDBService>();
            builder.Services.AddSingleton<UniversalDBService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AdminPage>();
            builder.Services.AddTransient<AdminProfilesPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<AuthService>();

            builder.Services.AddTransient<LoadingPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignupPage>();
            builder.Services.AddTransient<PostJob>();
            builder.Services.AddTransient<ProfilePage>();
            return builder.Build();
        }
    }
}
