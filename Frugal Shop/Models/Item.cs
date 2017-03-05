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

namespace Frugal_Shop.Models
{
    public class SaleItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Thumbnail { get; set; }
        public DateTime DateAdded { get; set; }
        public string Img { get; set; }
        public string SaleType { get; set; }
        public string ItemType { get; set; }
        public string CategoryType { get; set; }
        public string Brand { get; set; }

    }

    public class SaleItemList
    {
        public List<SaleItem> ListSaleItems { get; set; }
    }
}