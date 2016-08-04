
using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Graphics.Drawables;
using System.IO;
using Android.Graphics;
using System.Net;

namespace MyGroceries
{

	public class ItemAdapter : BaseAdapter<GroceryItem>
	{
		Activity         context;
		List<GroceryItem> itemList;

		public ItemAdapter(Activity context, List<GroceryItem> itemList)
		{
			this.context     = context;
			this.itemList = itemList;
		}

		public override GroceryItem this[int position]
		{
			get
			{
				return itemList[position];
			}
		}

		public override int Count
		{
			get
			{
				return itemList.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = context.LayoutInflater.Inflate(Resource.Layout.ItemRow, parent, false);

			var photo     = view.FindViewById<ImageView>(Resource.Id.photoImageView);
			var heading      = view.FindViewById<TextView >(Resource.Id.headingTextView);
			var subheading = view.FindViewById<TextView >(Resource.Id.subHeadingTextView);

			//Stream   stream   = context.Assets.Open(itemList[position].ImageUrl);

			//Stream   stream   = itemList[position].ItemPhoto.Url;
			//Drawable drawable = Drawable.CreateFromStream(stream, null);
			//photo.SetImageDrawable(drawable);

			Bitmap bitmap = GetBitmapFromUrl (itemList [position].ItemPhoto.Url.ToString());

			photo.SetImageBitmap (bitmap);
			heading.Text = itemList[position].ItemName;
			subheading.Text = itemList[position].ItemCount.ToString();

			return view;
		}

		 private Bitmap GetBitmapFromUrl(string Url){
			using (WebClient webClient = new WebClient ()) {
			
				byte[] bytes = webClient.DownloadData (Url);
				if (bytes != null && bytes.Length > 0) {
					return  BitmapFactory.DecodeByteArray (bytes, 0, bytes.Length);
				}
			
			}

			return null;
		}
	}
}