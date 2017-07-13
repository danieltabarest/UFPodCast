using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.Generic;
using UFPodCast.ViewModels;
using System.ComponentModel;
using UFPodCast.Models;
using UFPodCast.Services;

namespace UFPodCast.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private ApiService apiService;
        private DataService dataService;
        private DialogService dialogService;
        private NavigationService navigationService;
        private bool isRefreshing = false;
        //private User currentUser;
        #endregion

        #region Properties
        //public LoginViewModel Login { get; set; }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }


        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();
            dataService = new DataService();

            LoadMenu();
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }
        #endregion

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_assignment_black_24dp.png",
                PageName = "SelectTournamentPage",
                Title = "Predictions",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_book_black_24dp.png",
                PageName = "SelectUserGroupsPage",
                Title = "Groups",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_card_membership_black_24dp.png",
                PageName = "SelectTournamentPage",
                Title = "Tournaments",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_format_list_numbered_black_24dp.png",
                PageName = "SelectTournamentPage",
                Title = "My Results",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_group_work_black_24dp.png",
                PageName = "ConfigPage",
                Title = "Config",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_close_black_24dp.png",
                PageName = "LoginPage",
                Title = "Logout",
            });
        }


    }
}