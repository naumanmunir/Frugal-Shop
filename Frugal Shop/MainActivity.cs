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
using Android.Graphics;
using Android.Content.Res;
using Frugal_Shop.Fragments;
using Android.Support.V4.Widget;

namespace Frugal_Shop
{
    [Activity(Label = "Frugal Shop", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar toolBar;
        private TabLayout tabLayout;
        private SupportFragment currSelectedFrag;
        private DrawerLayout drawerLayout;
        private NavigationView navigationView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolBar);
       
            SetSupportActionBar(toolBar);

            //FOR BACK TO HOME BUTTON
            //SupportActionBar.SetHomeButtonEnabled(true);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            SetTabs();
            ChangeTitleFont();

            //settingsFrag = new SettingsFragment();
            //currSelectedFrag = settingsFrag;

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
                case Resource.Id.action_search:
                    StartActivity(new Android.Content.Intent(this, new SearchActivity().Class));
                    OverridePendingTransition(Resource.Animation.right_slide_in, Resource.Animation.activity_close_scale);
                    return true;
                case Resource.Id.action_settings:
                    StartActivity(new Android.Content.Intent(this, new sett().Class));
                    OverridePendingTransition(Resource.Animation.right_slide_in, Resource.Animation.activity_close_scale);
                    //ShowFragment(settingsFrag);
                    return true;
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
;
        }

        private void ShowFragment(SupportFragment frag)
        {
            if (!frag.IsVisible)
            {
                
                var trans = SupportFragmentManager.BeginTransaction();

                trans.SetCustomAnimations(Resource.Animation.right_slide_in, Resource.Animation.right_slide_out, Resource.Animation.right_slide_in, Resource.Animation.right_slide_out);

                trans.Add(Resource.Id.fragmentContainer, frag);

                trans.Hide(currSelectedFrag);
                trans.Show(frag);
                trans.AddToBackStack(null);
                trans.Commit();

                currSelectedFrag = frag;
            }
        }

        public void ChangeTitleFont()
        {
            Typeface typeFace = Typeface.CreateFromAsset(this.Assets, "fonts/ChargerBd.otf");

            //SupportActionBar ab = SupportActionBar;
            TextView toolbarTitle = (TextView)FindViewById(Resource.Id.toolbar_title);
            toolbarTitle.SetTypeface(typeFace, TypefaceStyle.Bold);
        }

        public void SetTabs()
        {
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.vpager);

            SetUpViewPager(viewPager);
            tabLayout.SetupWithViewPager(viewPager);
            
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter tAdapter = new TabAdapter(SupportFragmentManager);

            tAdapter.AddFragment(new WomenItemFragment(), "Women");
            tAdapter.AddFragment(new MenItemFragment(), "Men");
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

}

