using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace SimpleCRUD
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            Button ViewP_button = FindViewById<Button>(Resource.Id.view_p);
            Button EditP_button = FindViewById<Button>(Resource.Id.edit_p);
            Button Exit_button = FindViewById<Button>(Resource.Id.exit);

            ViewP_button.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(ViewActivity));
                StartActivity(intent);
            };
            EditP_button.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(EditActivity));
                StartActivity(intent);
            };
            Exit_button.Click += (sender, e) =>
            {
                System.Environment.Exit(0);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}