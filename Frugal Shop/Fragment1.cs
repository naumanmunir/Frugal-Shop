using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;

namespace Frugal_Shop
{
    public class Fragment1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //RecyclerView recyclerView = inflater.Inflate(Resource.Layout.fragment, container, false) as RecyclerView;
            //recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            View view = inflater.Inflate(Resource.Layout.fragment, container, false);

            return view;
        }

        //private void SetUpRecyclerView(RecyclerView recyclerView)
        //{
        //    //var values = GetRandomSubList(Cheeses.CheeseStrings, 30);

        //    List<string> val = new List<string>();
        //    val.Add("Guess");
        //    val.Add("Macys");
        //    val.Add("Adidas");
            
            
        //    //recyclerView.SetAdapter(new SimpleStringRecyclerViewAdapter(recyclerView.Context, values, Activity.Resources));
        //}
    }
}