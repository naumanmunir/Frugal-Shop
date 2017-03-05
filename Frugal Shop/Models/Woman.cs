using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Frugal_Shop.Models
{
    public class tWoman
    {

        public int id { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Thumbnail { get; set; }

    }

    public class tWomanListModel
    {
        public List<tWoman> tWomanList { get; set; }
    }
}