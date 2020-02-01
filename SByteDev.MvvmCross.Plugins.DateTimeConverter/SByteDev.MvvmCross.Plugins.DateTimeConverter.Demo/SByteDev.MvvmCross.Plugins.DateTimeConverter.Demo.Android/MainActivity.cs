using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace SByteDev.MvvmCross.Plugins.DateTimeConverter.Demo.Android
{
    [Activity(Theme = "@style/Theme.AppCompat.Light")]
    [MvxActivityPresentation]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Title = "Date and Time Converters";

            SetContentView(Resource.Layout.Main);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Refresh").SetShowAsAction(ShowAsAction.IfRoom);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.home)
            {
                return base.OnOptionsItemSelected(item);
            }

            ViewModel.RefreshCurrentDateTimeCommand.Execute(null);

            return true;
        }
    }
}