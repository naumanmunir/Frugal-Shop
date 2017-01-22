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
using Android.Support.V7.Widget;
using Android.Support.V4.App;
using static Android.Support.V7.Widget.RecyclerView;
using Frugal_Shop.Models;

namespace Frugal_Shop
{
    public class Fragment2 : Android.Support.V4.App.Fragment
    {
        private RecyclerView recyclerView;
        private RecyclerView.Adapter rcAdapter;
        private RecyclerView.LayoutManager rcLayoutManager;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); 

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            recyclerView = inflater.Inflate(Resource.Layout.fragment2, container, false) as RecyclerView;
            rcLayoutManager = new LinearLayoutManager(recyclerView.Context);
            recyclerView.SetLayoutManager(rcLayoutManager);

            rcAdapter = new ItemAdapter();
            recyclerView.SetAdapter(rcAdapter);

            return recyclerView;
        }
    }

    public class ItemAdapter : RecyclerView.Adapter
    {
        private List<string> dataset;
        private List<tMan> manItemList;

        public ItemAdapter()
        {
            dataset = new List<string>();
            manItemList = new List<tMan>();
            frugalservice.WebService1 fs = new frugalservice.WebService1();

            var mItemList = fs.RetrieveManSale().ToList();

            foreach (var item in mItemList)
            {
                tMan m = new tMan();

                m.id = item.id;
                m.Title = item.Title;
                m.Domain = item.Domain;
                m.Thumbnail = item.Thumbnail;
                
                manItemList.Add(m);
            }
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
            //dataset.Add("Hi");
        }

        public override int ItemCount
        {
            get
            {
                return manItemList.Count;
            }
        }

        //When the view holder is data binding
        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            var simpleHolder = holder as SimpleViewHolderExtender;

            simpleHolder.textview.Text = manItemList[position].Title;

            Random rnd = new Random();
            simpleHolder.cardView.SetCardBackgroundColor(Android.Graphics.Color.Argb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            
        }

        //when the ViewHolder is created
        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item, parent, false);
            
            return new SimpleViewHolderExtender(v);
        }
    }

    public class SimpleViewHolderExtender : ViewHolder
    {
        public View mView;
        public TextView textview;
        public CardView cardView;

        public SimpleViewHolderExtender(View v):base(v)
        {
            mView = v;
            textview = v.FindViewById<TextView>(Resource.Id.text1);
            cardView = v.FindViewById<CardView>(Resource.Id.card_view);

            
        }

        public override string ToString()
        {
            return base.ToString() + " '" + textview.Text;
        }
    }
}