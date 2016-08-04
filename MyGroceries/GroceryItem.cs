using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parse;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyGroceries
{
        public class GroceryItem
        {
            public GroceryItem()
            {
            }
            public string ItemName { get; set; }
            public ParseFile ItemPhoto { get; set; }
            public int ItemCount { get; set; }
            public bool IsInCart { get; set; }
            public string ObjectID { get; set; }
            public override string ToString()
            {
                return ItemName + " (" + ItemCount.ToString() + ")";
            }
        }
    }
