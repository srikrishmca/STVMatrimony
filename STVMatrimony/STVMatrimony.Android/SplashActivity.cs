using Android.App;
using Android.Content.PM;
using Android.OS;

namespace STVMatrimony.Droid
{
    [Activity(Theme = "@style/Theme.Splash", Icon = "@mipmap/icon", MainLauncher = true,
       LaunchMode = LaunchMode.SingleInstance, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]

    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));

            // Create your application here
        }
    }
}