﻿using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views.InputMethods;
using Plugin.CurrentActivity;
using UFPodCast.CustomRenderers;
using UFPodCast.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Support.V7.Widget.SearchView;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace UFPodCast.Droid.CustomRenderer
{
    public class SearchPageRenderer : PageRenderer
    {
        private SearchView _searchView;

        private static Toolbar GetToolbar() => (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Toolbar>(Resource.Id.toolbar);
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            AddSearchToToolBar();
        }

        protected override void Dispose(bool disposing)
        {
            var ToolBar = GetToolbar();
            if (_searchView != null)
            {
                _searchView.QueryTextChange += searchView_QueryTextChange;
                _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            }
            //MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            ToolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            base.Dispose(disposing);
        }

        private void AddSearchToToolBar()
        {
            var ToolBar = GetToolbar();


            if (ToolBar == null || Element == null)
            {
                return;
            }


            //if (MainActivity.ToolBar == null || Element == null)
            //{
            //    return;
            //}

            ToolBar.Title = Element.Title;
            ToolBar.InflateMenu(Resource.Menu.mainmenu);

            //MainActivity.ToolBar.Title = Element.Title;
            //MainActivity.ToolBar.InflateMenu(Resource.Menu.mainmenu);

            //_searchView = MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();
            _searchView = ToolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            if (_searchView == null)
            {
                return;
            }

            _searchView.QueryTextChange += searchView_QueryTextChange;
            _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            _searchView.QueryHint = (Element as SearchPage)?.SearchPlaceHolderText;
            _searchView.ImeOptions = (int)ImeAction.Search;
            _searchView.InputType = (int)InputTypes.TextVariationNormal;
            _searchView.MaxWidth = int.MaxValue;        //Hack to go full width - http://stackoverflow.com/questions/31456102/searchview-doesnt-expand-full-width
        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var searchPage = Element as SearchPage;
            if (searchPage == null)
            {
                return;
            }
            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as SearchPage;
            if (searchPage == null)
            {
                return;
            }
            searchPage.SearchText = e?.NewText;


            if (e == null)
            {
                return;
            }

            searchPage.SearchCommand?.Execute(e?.NewText);
            e.Handled = true;
        }
    }
}