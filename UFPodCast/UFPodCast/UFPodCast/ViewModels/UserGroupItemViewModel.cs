using GalaSoft.MvvmLight.Command;
using UFPodCast.Models;
using UFPodCast.Services;
using System.Windows.Input;


namespace UFPodCast.ViewModels
{

    namespace Soccer.ViewModels
    {

        public class UserGroupItemViewModel //: UserGroup
        {

            private NavigationService navigationService;


            public UserGroupItemViewModel()
            {
                navigationService = new NavigationService();
            }

            //public ICommand SelectGroupCommand { get { return new RelayCommand(SelectGroup); } }

            //private async void SelectGroup()
            //{
            //    var mainViewModel = MainViewModel.GetInstance();
            //    mainViewModel.UserGroup= new UserGroupViewModel(this);
            //    await navigationService.Navigate("UserGroupPage");
            //}

        }

    }
}
