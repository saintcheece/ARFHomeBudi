using ARFHomeBudi.Services;

namespace ARFHomeBudi.Pages;

public partial class AdminPage : ContentPage
{
    private readonly CategoryDBService _categoryDB;
    private readonly AuthService authService;

    public int _editCatID;

    public AdminPage(CategoryDBService dbService)
	{
		InitializeComponent();
        _categoryDB = dbService;
        this.authService = new AuthService();
        Task.Run(async () => listView.ItemsSource = await _categoryDB.GetCategories());
    }

    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (_editCatID == 0)
            {
                await _categoryDB.Create(new Category
                {
                    Cat_Name = CatName.Text,
                    Cat_Rate = float.Parse(CatPrice.Text)
                });
            }
            else
            {
                await _categoryDB.Update(new Category
                {
                    Cat_ID = _editCatID,
                    Cat_Name = CatName.Text,
                    Cat_Rate = float.Parse(CatPrice.Text)
                });
                _editCatID = 0;
            }

            CatName.Text = string.Empty;
            CatPrice.Text = string.Empty;
        }
        catch (Exception err)
        {
            DisplayAlert("There's something wrong with that response, please check and try again.", err.ToString(), "OK");
        }

        listView.ItemsSource = await _categoryDB.GetCategories();

    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var cat = (Category)e.Item;

        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editCatID = cat.Cat_ID;
                CatName.Text = cat.Cat_Name;
                CatPrice.Text = cat.Cat_Rate.ToString();
                break;

            case "Delete":
                await _categoryDB.Delete(cat);
                listView.ItemsSource = await _categoryDB.GetCategories();
                break;
        }
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        authService.Logout();
        await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}");
    }
}