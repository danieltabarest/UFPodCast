using UFPodCast.ViewModels;
using UFPodCast.Models;
using UFPodCast.Views;
using System.Threading.Tasks;

namespace UFPodCast.Services
{
    public class NavigationService
    {
        #region Attributes
        private DataService dataService;
        #endregion

        #region Constructors
        public NavigationService()
        {
            dataService = new DataService();
        }
        #endregion

        #region Methods

        public async Task Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            //var mainViewModel = MainViewModel.GetInstance();

            switch (pageName)
            {

                case "mas":
                    await App.Navigator.PushAsync(new MasterPage());
                    break;

                default:
                    break;
            }
        }

        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                case "":
                    //App.Current.MainPage = new LoginPage();
                    break;
                default:
                    break;
            }
        }


        public async Task Back()
        {
            await App.Navigator.PopAsync();
        }

        public async Task Clear()
        {
            await App.Navigator.PopToRootAsync();
        }
        #endregion
    }
}
