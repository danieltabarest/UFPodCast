
using UFPodCast.ViewModels;
using Xamarin.Forms;

namespace UFPodCast.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            //var vm = MainViewModel.GetInstance();
            SetMainPage();
            //base.Appearing += (object sender, System.EventArgs e) =>
            //{
            //    //vm.RefreshPointsCommand.Execute(this);
            //};
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //var mainViewModel = MainViewModel.GetInstance();
            
        }

        public static void SetMainPage()
        {
            App.Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
