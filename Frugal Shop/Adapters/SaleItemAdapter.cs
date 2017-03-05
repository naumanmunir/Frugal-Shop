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
using Frugal_Shop.Models;
using static Android.Support.V7.Widget.RecyclerView;
using FFImageLoading;

namespace Frugal_Shop.Adapters
{
    public class SaleItemAdapter : RecyclerView.Adapter
    {
        private List<SaleItem> saleItemList;

        public SaleItemAdapter(string category)
        {
            saleItemList = new List<SaleItem>();
            frugalservice.WebService1 fs = new frugalservice.WebService1();

            var wItemList = fs.RetrieveSales(category).ToList();

            foreach (var item in wItemList)
            {
                SaleItem si = new SaleItem();
                si.ID = item.id;
                si.Title = item.Title;
                si.Domain = item.Domain;
                si.Img = item.Img;
                si.Brand = item.Brand;
                si.DateAdded = item.DateAdded;
                si.CategoryType = item.CategoryType;
                si.Thumbnail = item.Thumbnail;

                saleItemList.Add(si);
            }
        }

        public override int ItemCount
        {
            get
            {
                return saleItemList.Count;
            }
        }

        //When the view holder is data binding
        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            var simpleHolder = holder as SaleItemViewHolder;

            simpleHolder.textview.Text = saleItemList[position].Title;
            simpleHolder.ItemURL = saleItemList[position].Domain;

            Random rnd = new Random();

            try
            {
                var url = saleItemList[position].Thumbnail;

                var imgurl = "http://pichakafoods.com/images/" + saleItemList[position].Img;
                ImageService.Instance.LoadUrl(imgurl).Into(simpleHolder.imgView);
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

            return new SaleItemViewHolder(v);
        }
    }

    public class SaleItemViewHolder : ViewHolder
    {
        public Android.Views.View mView;
        public TextView textview { get; set; }
        public CardView cardView { get; set; }
        public FFImageLoading.Views.ImageViewAsync imgView { get; set; }
        public string ItemURL { get; set; }

        public SaleItemViewHolder(Android.Views.View v) : base(v)
        {
            mView = v;
            textview = v.FindViewById<TextView>(Resource.Id.text1);
            cardView = v.FindViewById<CardView>(Resource.Id.card_view);
            imgView = v.FindViewById<FFImageLoading.Views.ImageViewAsync>(Resource.Id.img_view);

            mView.Click += ItemClick;
        }

        private void ItemClick(object sender, EventArgs e)
        {
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