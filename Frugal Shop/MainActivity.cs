using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Xamarin.Forms;
using Android.Support.V4.App;
using System;
using Java.Lang;
using com.refractored;
using Android.Support.V4.View;
using Android.Support.V7.Widget;

namespace Frugal_Shop
{
    [Activity(Label = "Frugal Shop", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar myToolBar;
        MyAdapter adapt;
        PagerSlidingTabStrip tabs;
        ViewPager pager;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);


            //adapt = new MyAdapter(SupportFragmentManager);
            //tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            //pager = FindViewById<ViewPager>(Resource.Id.pager);

            //pager.Adapter = adapt;
            //tabs.SetViewPager(pager);
            //tabs.SetBackgroundColor(Android.Graphics.Color.Argb(255, 0, 149, 164));

        }

        public override void SetSupportActionBar(Android.Support.V7.Widget.Toolbar toolbar)
        {
            myToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(myToolBar);
        }
    }


    public class MyAdapter : FragmentPagerAdapter
    {
        int tabCount = 3;

        public MyAdapter(Android.Support.V4.App.FragmentManager fm):base(fm)
        {

        }

        public override int Count
        {
            get
            {
                return tabCount;
            }
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            ICharSequence cs;

            if (position == 0)
            {
                cs = new Java.Lang.String("Man");
            }
            else if (position == 1)
            {
                cs = new Java.Lang.String("Woman");
            }
            else
            {
                cs = new Java.Lang.String("Home");
            }

            return cs;
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return ContentFragment.NewInstance(position);
        }
    }

}

