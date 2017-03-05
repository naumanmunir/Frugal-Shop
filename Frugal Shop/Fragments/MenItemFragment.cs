using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using Frugal_Shop.Adapters;

namespace Frugal_Shop.Fragments
{
    public class MenItemFragment : Android.Support.V4.App.Fragment
    {
        private RecyclerView recyclerView;
        private RecyclerView.Adapter rcAdapter;
        private RecyclerView.LayoutManager rcLayoutManager;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            recyclerView = inflater.Inflate(Resource.Layout.fragment, container, false) as RecyclerView;
            rcLayoutManager = new LinearLayoutManager(recyclerView.Context);
            recyclerView.SetLayoutManager(rcLayoutManager);

            rcAdapter = new SaleItemAdapter("Man");
            recyclerView.SetAdapter(rcAdapter);

            return recyclerView;
        }
    }
}