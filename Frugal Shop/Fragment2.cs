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
using Android.Graphics;
using System.Net;
using Xamarin.Forms;
using static Android.Views.View;

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

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            recyclerView = inflater.Inflate(Resource.Layout.fragment2, container, false) as RecyclerView;
            rcLayoutManager = new LinearLayoutManager(recyclerView.Context);
            recyclerView.SetLayoutManager(rcLayoutManager);

            rcAdapter = new MenItemAdapter();
            //recyclerView.SetAdapter(rcAdapter);

            return recyclerView;
        }
    }

    public class MenItemAdapter : RecyclerView.Adapter
    {
        private List<string> dataset;
        private List<tMan> manItemList;
        private List<SaleItem> saleItemList;

        public MenItemAdapter()
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
            simpleHolder.ItemURL = manItemList[position].Domain;

            Random rnd = new Random();
            //simpleHolder.cardView.SetCardBackgroundColor(Android.Graphics.Color.Argb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            //
            try
            {
                Bitmap imageBitmap = null;
                var url = manItemList[position].Thumbnail;

                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

                        simpleHolder.imgView.SetImageBitmap(imageBitmap);
                    }
                }

                var img = new Image();

                img.Source = manItemList[position].Thumbnail;
                

            }
            catch (Exception)
            {
                simpleHolder.imgView.SetBackgroundColor(Android.Graphics.Color.Argb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            }
            
        }

        public override int GetItemViewType(int position)
        {
            return position;
        }

        //when the ViewHolder is created
        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Android.Views.View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item, parent, false);
            
            return new SimpleViewHolderExtender(v);
        }
    }

    public class SimpleViewHolderExtender : ViewHolder
    {
        public Android.Views.View mView;
        public TextView textview { get; set; }
        public CardView cardView { get; set; }
        public ImageView imgView { get; set; }
        public string ItemURL { get; set; }

        public SimpleViewHolderExtender(Android.Views.View v):base(v)
        {
            mView = v;
            textview = v.FindViewById<TextView>(Resource.Id.text1);
            cardView = v.FindViewById<CardView>(Resource.Id.card_view);
            imgView = v.FindViewById<ImageView>(Resource.Id.img_view);

            mView.Click += ItemClick;
        }

        private void ItemClick(object sender, EventArgs e)
        {
            //Toast.MakeText(mView.Context, textview.Text, ToastLength.Short).Show();
            var url = Android.Net.Uri.Parse("http://www." + ItemURL);
            Intent intent = new Intent(Intent.ActionView, url);
            mView.Context.StartActivity(intent);
            
        }

        public override string ToString()
        {
            return base.ToString() + " '" + textview.Text;
        }


    }
}