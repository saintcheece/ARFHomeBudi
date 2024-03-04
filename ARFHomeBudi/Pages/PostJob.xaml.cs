using ARFHomeBudi.Services;
using System.Diagnostics.Metrics;
namespace ARFHomeBudi.Pages;

public partial class PostJob : ContentPage
{
    private readonly JobDBService _jobDB;
    private readonly CategoryDBService _catDB;

    public int SelectedCategory;

	public PostJob(JobDBService jobDBService, CategoryDBService catDBService)
	{
		InitializeComponent();
        AssignCategoryPick();
        _jobDB = jobDBService;
        _catDB = catDBService;
        JobAddPay.Text = "0";
        //Task.Run(async () => listView.ItemsSource = await _jobDB.GetJobOffers());
    }

    public async Task AssignCategoryPick() {
        await Task.Run(async () =>
        {
            var categories = await _catDB.GetCategories();

            var catIDs = categories.Select(c => c.Cat_ID).ToArray();
            var catNames = categories.Select(c => c.Cat_Name).ToArray();
            var catRates = categories.Select(c => c.Cat_Rate).ToArray();

            JobCat.ItemsSource = catNames;
        });
    }

    private async void PostJob_Clicked(object sender, EventArgs e)
    {
        await _jobDB.Create(new JobOffer
        {
            U_ID = (int)Globals.USER_ID,
            Job_Title = JobTitle.Text,
            Cat_ID = SelectedCategory,
            Job_Desc = JobDesc.Text,
            Job_Len = int.Parse(JobLen.Text),
            Job_Sched = JobSched.Date,
            Job_Cut = await GetCategoryRate(SelectedCategory) * float.Parse(JobLen.Text) * float.Parse("0.01"),
            Job_AddPay = float.Parse(JobAddPay.Text)
        });

        JobTitle.Text = string.Empty;
        JobCat.SelectedIndex = 1;
        JobDesc.Text = string.Empty;
        JobLen.Text = string.Empty;
        JobSched.Date = DateTime.Today;
        JobAddPay.Text = string.Empty;

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    public async void OnCategoryIndexChanged(object sender, EventArgs e)
    {
        var record = await _catDB.GetByName(JobCat.SelectedItem.ToString());
        SelectedCategory = record.Cat_ID;
    }

    public async Task<float> GetCategoryRate(int id)
    {
        var temp = await _catDB.GetByID(id);
        return temp.Cat_Rate;
    }
}