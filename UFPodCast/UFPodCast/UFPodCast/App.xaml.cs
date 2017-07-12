using UFPodCast.Services;
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
            InitializeComponent();

            SetMainPage();
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
    }
}
