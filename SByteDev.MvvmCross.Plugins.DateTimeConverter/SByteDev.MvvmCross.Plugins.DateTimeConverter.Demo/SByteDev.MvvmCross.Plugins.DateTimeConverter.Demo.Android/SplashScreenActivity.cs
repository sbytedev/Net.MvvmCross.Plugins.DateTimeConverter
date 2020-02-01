using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace SByteDev.MvvmCross.Plugins.DateTimeConverter.Demo.Android
{
    [Activity(
        MainLauncher = true,
        Theme = "@style/Theme.AppCompat.Light.NoActionBar",
        NoHistory = true
    )]
    public sealed class SplashScreenActivity : MvxSplashScreenAppCompatActivity<MvxAppCompatSetup<App>, App>
    {
    }
}