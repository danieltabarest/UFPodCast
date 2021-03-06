﻿using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using ImageCircle.Forms.Plugin.Droid;
using Plugin.MediaManager.Forms;
using System;
using Xamarin.Forms;

namespace UFPodCast.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Android.Support.V7.Widget.Toolbar ToolBar { get; private set; }
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);
            Plugin.MediaManager.Forms.Android.VideoViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            ImageCircleRenderer.Init();
            LoadApplication(new App());
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            ToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            return base.OnCreateOptionsMenu(menu);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}