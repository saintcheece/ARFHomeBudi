using ARFHomeBudi.Services;

namespace ARFHomeBudi.Pages;

public partial class AdminProfilesPage : ContentPage
{
	private readonly UserDBService _userDBService;
    private readonly AuthService authService;
    private int _editUserID;
    public AdminProfilesPage(UserDBService dbService)
	{
		InitializeComponent();
		_userDBService = dbService;
        this.authService = new AuthService();
		Task.Run(async () => listView.ItemsSource = await _userDBService.GetReadable());
	}

    public async void Register_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (_editUserID == 0)
            {
                await _userDBService.Create(new User
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
                    U_Role = int.Parse(Role.Text),
                    U_IsRequesting = CheckRequest(),
                    U_Clearance = NBI.Text,
                    U_FB = FB.Text,
                    U_LIn = null,
                    U_Resume = null,
                    U_Stat = 1
                });
            }
            else
            {
                await _userDBService.Update(new User
                {
                    U_ID = _editUserID,
                    U_Email = Email.Text,
                    U_Pass = Password.Text,
                    U_FName = FirstName.Text,
                    U_LName = LastName.Text,
                    U_Cntry = Country.Text,
                    U_City = City.Text,
                    U_Prov = Province.Text,
                    U_Town = Town.Text,
                    U_HNum = HouseNum.Text,
                    U_Role = int.Parse(Role.Text),
                    U_IsRequesting = CheckRequest(),
                    U_Clearance = NBI.Text,
                    U_FB = FB.Text,
                    U_LIn = null,
                    U_Resume = null,
                    U_Stat = 1
                });

                _editUserID = 0;
            }
        }
        catch
        {
        }

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
        Role.Text = string.Empty;
        IsRequestingRadioButton.IsChecked = false;
        IsNotRequestingRadioButton.IsChecked = false;

        await Task.Run(async () => listView.ItemsSource = await _userDBService.GetReadable());
    }

    public bool CheckRequest() {
        bool val;
        if (IsRequestingRadioButton.IsChecked)
        {
            val = true;
            return val;
        }
        else if(IsNotRequestingRadioButton.IsChecked)
        {
            val = false;
            return val;
        }
        else {
            return false;
        }
    }

    public void CheckRequested(bool x)
    {
        if (x == true) {
            IsRequestingRadioButton.IsChecked = true;
        }
        else
        {
            IsNotRequestingRadioButton.IsChecked = true;
        }
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var user = (User)e.Item;

        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editUserID = user.U_ID;
                Email.Text = user.U_Email;
                Password.Text = user.U_Pass;
                FirstName.Text = user.U_FName;
                LastName.Text = user.U_LName;
                Country.Text = user.U_Cntry;
                City.Text = user.U_City;
                Province.Text = user.U_Prov;
                Town.Text = user.U_Town;
                HouseNum.Text = user.U_HNum;
                Role.Text = user.U_Role.ToString();
                CheckRequested(user.U_IsRequesting);
                NBI.Text = user.U_Clearance;
                FB.Text = user.U_FB;
                break;

            case "Delete":
                await _userDBService.Delete(user);
                listView.ItemsSource = await _userDBService.GetUsers();
                break;
        }
    }

    private async void Search_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Search.Text == string.Empty)
        {
            listView.ItemsSource = await _userDBService.GetReadable();
        }
        else
        {
            listView.ItemsSource = await _userDBService.GetSearch(Search.Text);
        }
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        authService.Logout();
        await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}");
    }
}