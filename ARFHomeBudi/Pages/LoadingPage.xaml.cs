using ARFHomeBudi.Pages;
using ARFHomeBudi.Services;
namespace ARFHomeBudi.Pages;

public partial class LoadingPage : ContentPage
{
	private readonly AuthService authService;
	public LoadingPage(AuthService authService)
	{
		InitializeComponent();
		this.authService = authService;
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		if(await authService.IsAuthenticatedAsync())
		{
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
		else
		{
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
	}
}