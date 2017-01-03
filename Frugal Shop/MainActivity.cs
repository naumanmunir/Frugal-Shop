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
using Android.Support.Design.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using System.Collections.Generic;
using Android.Text;
using Android.Text.Style;
using Android.Views;

namespace Frugal_Shop
{
    [Activity(Label = "Frugal Shop", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar toolBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SpannableString s = new SpannableString("Frugal Shop");
            s.SetSpan(new TypefaceSpan("Assets/fonts/BrightLarch.ttf"), 0, s.Length(), SpanTypes.ExclusiveExclusive);
            
            SupportActionBar ab = SupportActionBar;
            ab.TitleFormatted = s;
            
            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.vpager);
            SetUpViewPager(viewPager);
            tabs.SetupWithViewPager(viewPager);


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_buttons, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //todo
                //case Resource.Id.action_favorite:
                //    return true;
                case Resource.Id.action_settings:
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter tAdapter = new TabAdapter(SupportFragmentManager);

            tAdapter.AddFragment(new Fragment1(), "Woman");
            tAdapter.AddFragment(new Fragment2(), "Man");
            tAdapter.AddFragment(new Fragment1(), "Home");

            viewPager.Adapter = tAdapter;
        }
    }

    public class TabAdapter : FragmentPagerAdapter
    {
        public List<SupportFragment> Fragments { get; set; }
        public List<string> FragmentNames { get; set; }

        public TabAdapter(SupportFragmentManager sfm) : base(sfm)
        {
            Fragments = new List<SupportFragment>();
            FragmentNames = new List<string>();
        }

        public void AddFragment(SupportFragment fragment, string name)
        {
            Fragments.Add(fragment);
            FragmentNames.Add(name);
        }

        public override int Count
        {
            get
            {
                return Fragments.Count;
            }
        }

        public override SupportFragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(FragmentNames[position]);
        }
    }

    //public class MyAdapter : FragmentPagerAdapter
    //{
    //    int tabCount = 3;

    //    public MyAdapter(Android.Support.V4.App.FragmentManager fm):base(fm)
    //    {

    //    }

    //    public override int Count
    //    {
    //        get
    //        {
    //            return tabCount;
    //        }
    //    }

    //    public override ICharSequence GetPageTitleFormatted(int position)
    //    {
    //        ICharSequence cs;

    //        if (position == 0)
    //        {
    //            cs = new Java.Lang.String("Man");
    //        }
    //        else if (position == 1)
    //        {
    //            cs = new Java.Lang.String("Woman");
    //        }
    //        else
    //        {
    //            cs = new Java.Lang.String("Home");
    //        }

    //        return cs;
    //    }

    //    public override Android.Support.V4.App.Fragment GetItem(int position)
    //    {
    //        return ContentFragment.NewInstance(position);
    //    }
    //}

}

