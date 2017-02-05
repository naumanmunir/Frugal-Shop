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
    public class tMan
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Thumbnail { get; set; }
    }

    public class tManListModel
    {
        public List<tMan> tManList { get; set; }
    }
}