using ARFHomeBudi.Pages;
using ARFHomeBudi.Services;
using SQLitePCL;
namespace ARFHomeBudi.Pages;

public partial class LoginPage : ContentPage
{

	private readonly AuthService authService;
	private readonly UserDBService _userDB;
	public LoginPage(UserDBService dbService)
	{
		InitializeComponent();
		this.authService = new AuthService();
		_userDB = dbService;
	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		var usr = await _userDB.VerifyUser(Email.Text, Password.Text);
        if (usr != null)
		{
			if (usr.U_Role == 1)
			{
				Globals.USER_ID = usr.U_ID;
				Globals.USER_ROLE = usr.U_Role;
				authService.Login();
				Email.Text = string.Empty;
				Password.Text = string.Empty;
				await Shell.Current.GoToAsync($"//{nameof(AdminProfilesPage)}");
			}else if(usr.U_Role == 3) {
                Globals.USER_ID = usr.U_ID;
                Globals.USER_ROLE = usr.U_Role;
                authService.Login();
                Email.Text = string.Empty;
                Password.Text = string.Empty;
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
		}
		else
		{
			DisplayAlert("Incorrect Email or Password", "", "OK");
		}
	}

    private async void Signup_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(SignupPage)}");
    }
}