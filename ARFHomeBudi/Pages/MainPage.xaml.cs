using ARFHomeBudi.Pages;
using ARFHomeBudi.Services;
using System.ComponentModel;
namespace ARFHomeBudi.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly UniversalDBService _universalDBService;


        public MainPage(UniversalDBService universaldbService)
        {
            InitializeComponent();
            _universalDBService = universaldbService;
            //Task.Run(async () => JobList.ItemsSource = await _universalDBService.GetJobOffersDetails());
        }

        private async void PostJob_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(PostJob)}");
        }
    }

}
