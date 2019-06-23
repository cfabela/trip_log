using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using TripLog.Droid.Modules;

namespace TripLog.Droid
{
    [Activity(Label = "TripLog", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
       // public static FirebaseApp firebaseApp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            InitFirebase();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App(new TripLogPlatformModule()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitFirebase()
        {
            //var options = new FirebaseOptions.Builder().
            //    SetApplicationId("1:609896559072:android:2515d65747fb0c34").
            //    SetDatabaseUrl("https://triplog-93404.firebaseio.com/").
            //    SetApiKey("AIzaSyD1Gv1RLAyYDkCpm1Vbb47wLepOkmY2YSE").Build();

            //if (firebaseApp == null)
            //    firebaseApp = FirebaseApp.InitializeApp(this, options, "TripLog");
        }

    }
}