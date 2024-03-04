using ARFHomeBudi.Pages;

namespace ARFHomeBudi
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PostJob), typeof(PostJob));
            Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
            Routing.RegisterRoute(nameof(AdminProfilesPage), typeof(AdminProfilesPage));
            Routing.RegisterRoute(nameof(AdminJobPage), typeof(AdminJobPage));
        }
    }
}