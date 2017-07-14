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
using System.Threading.Tasks;
using UFPodCast.Helpers;
using UFPodCast.Views;
using GalaSoft.MvvmLight.Command;

namespace UFPodCast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private DataService dataService;
        private DialogService dialogService;
        private NavigationService navigationService;
        private bool isRefreshing = false;
        #endregion

        #region Properties
        public PodCastViewModel PodCastViewModel { get; set; }

        public PodCastViewModel ItemDetailViewModel { get; set; }

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

            //Title = "Browse";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

            LoadMenu();
        }
        #endregion





        #region Events
        public ObservableRangeCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

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


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }


        public ICommand SelectPodCastCommand { get { return new RelayCommand(SelectPodCast); } }

        private async void SelectPodCast()
        {
            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.ItemDetailViewModel = new ItemDetailViewModel(this);
            await navigationService.Navigate("EditPreditionsPage");
        }


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
                Title = "Testing",
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