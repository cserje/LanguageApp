using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LanguageKing.Droid
{
    [Activity(Label = "LanguageKing", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            //var localPlayers = Application.Context.GetSharedPreferences("Players", Android.Content.FileCreationMode.Private);
            //string name = localPlayers.GetString("Name",null);
            //int points = localPlayers.GetInt("Points", 0);
            //Player myPlayer = new Player(name, points);
            //Player[] playerList = { myPlayer };
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

