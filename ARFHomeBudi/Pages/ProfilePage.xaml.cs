using ARFHomeBudi.Services;

namespace ARFHomeBudi.Pages;

public partial class ProfilePage : ContentPage
{

    private readonly AuthService authService;
    private readonly UserDBService _userDB;

    public int uid = (int)Globals.USER_ID;

    public string FName;
    public string LName;

    public string UCity;
    public string UProv;

    public User user;

    public ProfilePage(UserDBService dbService)
	{
		InitializeComponent();
        this.authService = new AuthService();
        _userDB = dbService;
        LoadUserAsync();
        BindingContext = user;
        Task.Run(async () => UserName.Text = ((await _userDB.GetByID(uid)).U_FName) + " " + (await _userDB.GetByID(uid)).U_LName);

        Task.Run(async () => UserLoc.Text = ((await _userDB.GetByID(uid)).U_City)+", "+(await _userDB.GetByID(uid)).U_City);
    }

    private async Task LoadUserAsync()
    {
        user = await _userDB.GetByID((int)Globals.USER_ID);
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        authService.Logout();
        await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}");
    }
}