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
using Android.Util;

namespace Frugal_Shop
{
    [Activity(Label = "SettingsActivity", Theme = "@style/MyTheme")]
    public class SettingsActivity : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar toolBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings);
            toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.custom_toolBar);

            SetSupportActionBar(toolBar);

            
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Create your application here
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
    }
}