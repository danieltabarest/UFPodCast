using GalaSoft.MvvmLight.Command;
using UFPodCast;
using UFPodCast.Models;
using UFPodCast.Services;
using System.Windows.Input;


namespace UFPodCast.ViewModels
{
    public class MenuItemViewModel
    {
        #region Attributes
        private NavigationService navigationService;
        private DataService dataService; 
        #endregion

        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Constructors
        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
            dataService = new DataService();
        }
        #endregion

        #region Commands
        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        private async void Navigate()
        {
            var mainviewModel = MainViewModel.GetInstance();
         
                switch (PageName)
                {
                    case "SelectTournamentPage":
                        //dataService.Update(parameters);
                        //mainviewModel.SelectTournament = new SelectTournamentViewModel();
                        await navigationService.Navigate(PageName);
                        break;
                    case "ConfigPage":
                        //mainviewModel.Config = new ConfigViewModel(mainviewModel.CurrentUser);
                        await navigationService.Navigate(PageName);
                        break;
                    case "SelectUserGroupsPage":
                        //mainviewModel.SelectUserGroup = new SelectUserGroupViewModel();
                        await navigationService.Navigate(PageName);
                        break;
                    //case "TournamentsPage":
                    //    //mainviewModel.TournamentGroup = new tour();
                    //    await navigationService.Navigate(PageName);
                    //    break;
                        
                    default:
                        break;
                
            }
        }

        #endregion
    }


}