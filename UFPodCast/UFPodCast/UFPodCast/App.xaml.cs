using UFPodCast.Services;
using UFPodCast.ViewModels;
using UFPodCast.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UFPodCast
{
    public partial class App : Application
    {
        #region Attributes
        private DataService dataService;
        private ApiService apiService;
        private DialogService dialogService;
        private NavigationService navigationService;
        #endregion
        public static App Instance;
        #region Properties
        public static NavigationPage Navigator { get; internal set; }

        public static MasterPage Master { get; internal set; }
        #endregion


        public App()
        {
            Instance = this;
            InitializeComponent();
            dialogService = new DialogService();
            apiService = new ApiService();
            dataService = new DataService();
            navigationService = new NavigationService();

            var mainViewModel = MainViewModel.GetInstance();
            MainPage = new MasterPage();

            //SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
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

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


    }
}
