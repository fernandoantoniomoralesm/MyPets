using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyPets.Droid
{
    [Activity(Label = "MyPets", Icon = "@drawable/ico1", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(16, 31, 39));
            LoadApplication(new App());
        }
    }
}