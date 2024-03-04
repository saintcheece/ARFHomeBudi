using ARFHomeBudi.Services;

namespace ARFHomeBudi.Pages;

public partial class AdminPage : ContentPage
{
    private readonly CategoryDBService _categoryDB;

	public AdminPage(CategoryDBService dbService)
	{
		InitializeComponent();
        _categoryDB = dbService;
        Task.Run(async () => listView.ItemsSource = await _categoryDB.GetCategories());
    }

    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            await _categoryDB.Create(new Category
            {
                Cat_Name = CatName.Text,
                Cat_Rate = float.Parse(CatPrice.Text)
            });
        }catch(Exception err)
        {
            DisplayAlert("Error", err.ToString(), "OK");
        }

        CatName.Text = string.Empty;
        CatPrice.Text = string.Empty;

        await Task.Run(async () => listView.ItemsSource = await _categoryDB.GetCategories());
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var cat = (Category)e.Item;

        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                CatName.Text = cat.Cat_Name;
                CatPrice.Text = cat.Cat_Rate.ToString();
                break;

            case "Delete":
                await _categoryDB.Delete(cat);
                listView.ItemsSource = await _categoryDB.GetCategories();
                break;
        }
    }
}