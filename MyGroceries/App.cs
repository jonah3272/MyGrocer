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
using Parse;

namespace MyGroceries
{
    [Application]
    public class App : Application
    {
        public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();

            // Initialize the Parse client with your Application ID and .NET Key found on
            // your Parse dashboard, this is a private security key for your Parse account
            // To find your key, select your application on Parse, go to "Settings",
            // then open the "Application Keys" tab.
            ParseClient.Initialize("CUNfGC7p88KX7KUr63RKjXFySKtr4UzthbbtWeqM", "Gacgnrq4UlvtqU4PDmuxkXwWQfhr7IQZkMTQrrsd");
        }
    }
}