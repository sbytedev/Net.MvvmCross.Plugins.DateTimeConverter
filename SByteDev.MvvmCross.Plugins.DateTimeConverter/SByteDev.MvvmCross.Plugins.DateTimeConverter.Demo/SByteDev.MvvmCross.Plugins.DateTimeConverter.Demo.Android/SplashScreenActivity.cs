using Android.App;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace SByteDev.MvvmCross.Plugins.DateTimeConverter.Demo.Android
{
    [Activity(
        MainLauncher = true,
        Theme = "@style/Theme.AppCompat.Light.NoActionBar",
        NoHistory = true
    )]
    public sealed class SplashScreenActivity : MvxSplashScreenActivity<MvxAndroidSetup<App>, App>
    {
    }
}