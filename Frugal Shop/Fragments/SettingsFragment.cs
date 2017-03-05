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
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Layout.preferences);

            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        
    }

    [Activity(Label = "sett", Theme = "@style/MyTheme")]
    public class sett : PreferenceActivity, Android.Views.View.IOnClickListener
    {
        private Android.Support.V7.Widget.Toolbar toolBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetActionBarTitle();

            
        }

        public override void SetContentView(int layoutResID)
        {

            var contentView = (ViewGroup)LayoutInflater.From(this).Inflate(
                Resource.Layout.settings, new LinearLayout(this), false);

            toolBar = contentView.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.custom_toolBar);

            toolBar.SetNavigationOnClickListener(this);

            

            ViewGroup contentWrapper = (ViewGroup)contentView.FindViewById(Resource.Id.PreferencesContainer);
            LayoutInflater.From(this).Inflate(layoutResID, contentWrapper, true);

            Window.SetContentView(contentView);
        }

        public override void OnBuildHeaders(IList<Header> target)
        {
            LoadHeadersFromResource(Resource.Xml.preference_headers, target);  
        }


        private void SetActionBarTitle()
        {
            View includeView = FindViewById(Resource.Id.settings_include_layout);

            var toolbarTitle = includeView.FindViewById<TextView>(Resource.Id.custom_toolbar_title);

            toolbarTitle.Text = "Settings";
        }

        public void OnClick(View v)
        {
            Finish();
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