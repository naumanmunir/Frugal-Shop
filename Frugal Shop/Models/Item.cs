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
    public class Item
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
    }
}