using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Frugal_Shop
{
    [Activity(Label = "SearchActivity", Theme = "@style/MyTheme")]
    public class SearchActivity : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar toolBar;
        private SearchView searchView;
        private ListView listView;
        private ArrayAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.search);
            toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.custom_toolBar_search);

            SetSupportActionBar(toolBar);
            SetActionBarTitle();

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);



            var products = new[]
            {
                "Dell Inspiron", "HTC One X", "HTC Wildfire S", "HTC Sense", "HTC Sensation XE",
                "iPhone 4S", "Samsung Galaxy Note 800",
                "Samsung Galaxy S3", "MacBook Air", "Mac Mini", "MacBook Pro"
            };

            listView = FindViewById<ListView>(Resource.Id.searchlistView);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, products);
            listView.Adapter = adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.actionbar_buttons, menu);

            //IMenuItem item = menu.FindItem(Resource.Id.action_search);
            //searchView = item.ActionView.JavaCast<Android.Widget.SearchView>();

            return true;
        }

        protected override void OnPause()
        {
            base.OnPause();

            OverridePendingTransition(Resource.Animation.activity_open_scale, Resource.Animation.right_slide_out);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //why cant I catch Resource.id.Home itemID ??? hard coded for now
                case 16908332:
                    Finish();
                    return true;
                default:
                    return false;
            }
        }

        private void SetActionBarTitle()
        {
            View includeView = FindViewById(Resource.Id.search_include_layout);
            searchView = includeView.FindViewById<SearchView>(Resource.Id.simpleSearchView);

            //searchView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffffff"));

            int searchIconId = this.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
            var icon = searchView.FindViewById(searchIconId) as ImageView;
            icon.LayoutParameters = new LinearLayout.LayoutParams(0, 0);
        }
    }
}