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
using System.Net.Http;
using Plugin.Connectivity;
using UFPodCast.Exceptions;

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
        string searchResult;
        bool isvisibleerror = false;
        bool isvisiblelistview = true;
        #endregion

        #region Properties
        //public PodCastViewModel ItemDetailViewModel { get; set; }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public List<Item> OldItem { get; set; }

        public bool IsVisibleError
        {
            get
            {
                return isvisibleerror;
            }

            set
            {
                isvisibleerror = value;
                OnPropertyChanged();
            }
        }
        public bool Enable { get; set; }

        public bool IsVisibleListView
        {
            get
            {
                return isvisiblelistview;
            }

            set
            {
                isvisiblelistview = value;
                OnPropertyChanged();
            }
        }
        

        public ObservableRangeCollection<Item> Items { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();
            dataService = new DataService();

            Items = new ObservableRangeCollection<Item>();
            OldItem = new List<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

            SearchCommand = new Command((object obj) =>
            {
                var value = (string)obj;
                Items.ReplaceRange(OldItem.Where(x => x.S_NOMBRE.Contains(value) || x.S_DESCRIPCION.Contains(value)));
            });

            LoadMenu();
        }
        #endregion





        #region Events
        public Command LoadItemsCommand { get; set; }

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
            Enable = true;
            IsBusy = true;

            try
            {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    await dialogService.ShowMessage("Error", "Check you internet connection.");
                    return;
                }

                var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
                if (!isReachable)
                {
                    await dialogService.ShowMessage("Error", "Check you internet connection.");
                    return;
                }

                var parameters = dataService.First<Parameter>(false);

                var response = await apiService.Get<Item>(parameters.URLBase, "/api", "/vListadoPodCasts");
                if (!response.IsSuccess)
                {
                    IsBusy = false;
                    Enable = false;
                    IsVisibleError = true;
                    IsVisibleListView = !IsVisibleError;
                    await dialogService.ShowMessage("Error", "Problem ocurred retrieving user information, try latter.");
                    return;
                }
                var podcast = (List<Item>)response.Result;
                Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(podcast);
                OldItem.AddRange(podcast);
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
                Enable = false;
            }
        }


        public ICommand SelectPodCastCommand { get { return new RelayCommand(SelectPodCast); } }


        public ICommand SearchCommand { get; }

        public string SearchResult
        {
            get
            {
                return searchResult;
            }

            set
            {
                searchResult = value;
                OnPropertyChanged();
            }
        }

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