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
using Android.Support.V4.Widget;

namespace Frugal_Shop
{
    public class ActionBarDrawer : ActionBarDrawerToggle
    {
        public ActionBarDrawer(ActionBarActivity host, DrawerLayout drawerLayout, int openedResource, int closedResource) 
            : base(host, drawerLayout, openedResource, closedResource)
        {
            
        }
    }
}