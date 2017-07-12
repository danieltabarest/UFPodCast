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
    public class MainViewModel //: INotifyPropertyChanged
    {
        #region Attributes
        private ApiService apiService;
        private DataService dataService;
        private DialogService dialogService;
        private NavigationService navigationService;
        private bool isRefreshing = false;
        //private User currentUser;
        #endregion

       

        #region Constructor
        public MainViewModel()
        {
          
        }
        #endregion

      
    }

}