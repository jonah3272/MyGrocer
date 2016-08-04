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
using System.IO;
using System.Threading.Tasks;

namespace MyGroceries
{
    [Activity(Label = "GroceriesActivity")]
    public class GroceriesActivity : Activity
    {
        ListView listViewGroceries;

        List<GroceryItem> GroceryItemList;
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Groceries);
            listViewGroceries =

           FindViewById<ListView>(Resource.Id.listViewGroceries);

            await LoadParseData();
            listViewGroceries.Adapter = new ItemAdapter(this, GroceryItemList);

            // TODO: wire up the ItemClick event
            listViewGroceries.ItemClick += OnItemClick;
        }
  
                async Task LoadParseData()
        {
            GroceryItemList = new List<GroceryItem> { };
            try
            {
                // Using LINQ
                var query = from groceryItems in
                 ParseObject.GetQuery("Groceries")
                                //where groceryItems["CreatedBy"] == ParseUser.CurrentUser
                            orderby groceryItems["ItemName"] ascending
                            select groceryItems;
                var parseGroceryItemList = await query.FindAsync();
                // if the returned list from Parse is not empty
                if (parseGroceryItemList != null)
                {
                    // loop through the results and create
                    foreach (var pGroceryItem in parseGroceryItemList)
                    {
                        var gItem = new GroceryItem()
                        {
                            ItemName = pGroceryItem.Get<string>("ItemName"),
                            ItemPhoto = pGroceryItem.Get<ParseFile>("ItemPhoto"),
                            ItemCount = pGroceryItem.Get<int>("ItemCount"),
                            IsInCart = pGroceryItem.Get<bool>("IsInCart"),
                            ObjectID = pGroceryItem.ObjectId,
                        };
                        GroceryItemList.Add(gItem);
                    }
                }
            }
            catch (Exception ex)
            {
                var dialog = new AlertDialog.Builder(this);
                dialog.SetMessage(ex.Message);
                dialog.SetNeutralButton("OK", delegate { });
                dialog.Show();
            }
        }
        void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var groceryItem = GroceryItemList[e.Position];
            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(groceryItem.ToString());
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }
    }
}