
using System;
using UFPodCast.CustomRenderers;
using UFPodCast.Models;
using UFPodCast.ViewModels;
using Xamarin.Forms;

namespace UFPodCast.Views
{
    public partial class MainPage : SearchPage
    {
        MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel =  MainViewModel.GetInstance(); ;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
