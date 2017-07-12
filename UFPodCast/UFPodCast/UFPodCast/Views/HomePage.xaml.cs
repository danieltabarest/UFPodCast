
using UFPodCast.ViewModels;
using Xamarin.Forms;

namespace UFPodCast.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            //var vm = MainViewModel.GetInstance();
            base.Appearing += (object sender, System.EventArgs e) =>
            {
                //vm.RefreshPointsCommand.Execute(this);
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //var mainViewModel = MainViewModel.GetInstance();
            
        }
    }
}
