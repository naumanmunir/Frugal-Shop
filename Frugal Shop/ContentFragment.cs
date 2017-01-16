using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace Frugal_Shop
{
    public class ContentFragment : Fragment
    {
        int position;

        public static ContentFragment NewInstance(int position)
        {
            var frag = new ContentFragment();
            var bundle = new Bundle();

            bundle.PutInt("position", position);
            frag.Arguments = bundle;
            
            return frag;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            position = Arguments.GetInt("position");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var root = inflater.Inflate(Resource.Layout.fragment, container, false);
            //var text = root.FindViewById<TextView>(Resource.Id.textView1);
            //text.SetTextColor(Android.Graphics.Color.Argb(255, 0, 0, 0));
            if (position == 0)
            {
                //text.Text = "Man";
            }
            else if (position == 1)
            {
                //text.Text = "Woman";
            }
            else
            {
                //text.Text = "Home";
            }

            ViewCompat.SetElevation(root, 50);

            return root;
        }
    }
}