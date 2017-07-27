using Acr.UserDialogs;
using FreshMvvm;
using System.Threading.Tasks;
using UFPodCast.Helpers;
using UFPodCast.Models;
using UFPodCast.Services;

using Xamarin.Forms;

namespace UFPodCast.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {

            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                if (value)
                    UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
                else
                    UserDialogs.Instance.HideLoading();
            }
            //get { return isBusy; }
            //set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        protected async Task ReAuthenticateAsync()
        {
            //await PushModalAsync<LoginPageModel>();
        }

        //protected async Task DisplayNoConnectionMessage()
        //{
        //    await PushModalAsync<NoConnectionMessagePageModel>();
        //}

        //protected async Task DisplayDataErrorMessage()
        //{
        //    await PushModalAsync<DataErrorMessagePageModel>();
        //}

        //protected async Task PushModalAsync<T>() where T : FreshBasePageModel
        //{
        //    await PushModalAsync<T>(null);
        //}
    }
}

