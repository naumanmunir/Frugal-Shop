using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Xamarin.Forms;

namespace Frugal_Shop
{
    [Activity(Label = "Frugal Shop", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity 
    {
        private Android.Support.V7.Widget.Toolbar myToolBar; 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            myToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(myToolBar);
            SupportActionBar.Title = "Frugal Shop";

        }
    }

    //Blue Page
    public class BluePage : ContentPage
    {
        public BluePage()
        {
            BackgroundColor = Color.Blue;
            Title = "Blue Page";
            Icon = "heart.png";
        }
    }

    // Red Page
    public class RedPage : ContentPage
    {
        public RedPage()
        {
            BackgroundColor = Color.Red;
            Title = "Red Page";
            Icon = "icecream.png";
        }
    }

    // TabPage
    public class TabPage : TabbedPage
    {
        public TabPage()
        {
            this.Children.Add(new BluePage());
            this.Children.Add(new RedPage());
        }
    }
}

