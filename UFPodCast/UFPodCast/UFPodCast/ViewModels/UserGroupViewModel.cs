using GalaSoft.MvvmLight.Command;
using UFPodCast.Models;
using UFPodCast.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;



namespace UFPodCast.ViewModels
{

    public class UserGroupViewModel //: UserGroup
    {

        private NavigationService navigationService;
        //private UserGroup usergrou;

        #region Attributes
        private ApiService apiService;
        private DataService dataService;
        private DialogService dialogService;
        #endregion

        #region Properties
        //public ObservableCollection<GroupUserItemViewModel> MyGroupsUsers { get; set; }
        #endregion

        public UserGroupViewModel(/*UserGroup usergrou*/)
        {
            //navigationService = new NavigationService();
            //this.usergrou = usergrou;

            ////UserGroupId = usergrou.UserGroupId;
            ////Name = usergrou.Name;
            ////Logo = usergrou.Logo;
            ////Owner = usergrou.Owner;
            ////GroupUsers = usergrou.GroupUsers;


            //MyGroupsUsers = new ObservableCollection<GroupUserItemViewModel>();

            ////LoadUserGroups();
            //ReloadGroupsUser(GroupUsers);
        }

        #region Singleton
        private static UserGroupViewModel instance;

        public static UserGroupViewModel GetInstance()
        {
            return instance;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        #endregion

        #region Commands
        public ICommand RefreshCommand { get { return new RelayCommand(Refresh); } }

        public void Refresh()
        {
            //LoadUserGroups();
        }
        #endregion
    }


}

