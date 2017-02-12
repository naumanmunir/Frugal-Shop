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
using Android.Preferences;

namespace Frugal_Shop.Fragments
{
    public class SettingsFragment : PreferenceFragment
    {
        private Android.Support.V7.Widget.Toolbar toolBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Layout.preferences);
            

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //View view = inflater.Inflate(Resource.Layout.settings, container, false);

            //toolBar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.custom_toolBar);
            //toolBar.BringToFront();
            //((AppCompatActivity)Activity).SetSupportActionBar(toolBar);

            //return view;

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}