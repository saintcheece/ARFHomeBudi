using ARFHomeBudi.Services;

namespace ARFHomeBudi.Pages;

public partial class SignupPage : ContentPage
{
    private readonly UserDBService _userDB;

	public SignupPage(UserDBService dbService)
	{
		InitializeComponent();
        _userDB = dbService;
	}

    private async void Login_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    public async void Signup_Clicked(object sender, EventArgs e)
    {
        try
        {
            await _userDB.Create(new User
            {
                U_Email = Email.Text,
                U_Pass = Password.Text,
                U_FName = FirstName.Text,
                U_LName = LastName.Text,
                U_Cntry = Country.Text,
                U_City = City.Text,
                U_Prov = Province.Text,
                U_Town = Town.Text,
                U_HNum = HouseNum.Text,
                U_Role = 3,
                U_IsRequesting = false,
                U_Clearance = NBI.Text,
                U_FB = FB.Text,
                U_LIn = null,
                U_Resume = null,
                U_Stat = 1
            });

            Email.Text = string.Empty;
            Password.Text = string.Empty;
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            Country.Text = string.Empty;
            City.Text = string.Empty;
            Province.Text = string.Empty;
            Town.Text = string.Empty;
            HouseNum.Text = string.Empty;
            NBI.Text = string.Empty;
            FB.Text = string.Empty;
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        catch
        {
        }
    }
}