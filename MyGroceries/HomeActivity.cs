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

namespace MyGroceries
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {

        Button btnList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            btnList = FindViewById<Button>(Resource.Id.btnList);
            btnList.Click += List_Click;

        }
        async void List_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(GroceriesActivity));
            StartActivity(intent);

        }
        }
}