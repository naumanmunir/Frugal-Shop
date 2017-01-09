using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Frugal_Shop.Fragments
{
    public class SettingsFragment : Android.Support.V4.App.Fragment
    {
        private Android.Support.V7.Widget.Toolbar toolBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);



            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.settings, container, false);

            var toolbarTitle = view.FindViewById<TextView>(Resource.Id.custom_toolbar_title);

            toolbarTitle.Text = "Settings";


            //toolBar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.custom_toolBar);
            //toolBar.BringToFront();
            //((AppCompatActivity)Activity).SetSupportActionBar(toolBar);

            return view;
        }
    }
}