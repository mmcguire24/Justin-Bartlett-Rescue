using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using DogData;
using SecondChanceRescue;
//using Koush;
//using Square.Picasso;
using SecondChanceResuce;
using Square.Picasso;
using AnimalRescue;

namespace Marcus.ListView.CustomListAdapter
{
	public class CustomListAdapter : BaseAdapter<Dog>
	{
		Activity context;
		List<Dog> list;

		public CustomListAdapter (Activity _context, List<Dog> _list)
			:base()
		{
			this.context = _context;
			this.list = _list;
			//Console.WriteLine(list[3].picUrl);

		}

		public override int Count {
			get { return list.Count; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Dog this[int index] {
			get { return list [index]; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 

			// re-use an existing view, if one is available
			// otherwise create a new one
			if (view == null)
				view = context.LayoutInflater.Inflate (Resource.Layout.ListItemRow, parent, false);

			Dog item = this [position];
			view.FindViewById<TextView> (Resource.Id.Title).Text = item.Name;
			view.FindViewById<TextView>(Resource.Id.Description).Text = item.Breed;
			ImageView thumbnail = (ImageView) view.FindViewById(Resource.Id.Thumbnail);

			Picasso.With (context).Load (list[position].getUrl()).Into (thumbnail);
			Console.WriteLine ("ListVeiw - " + list[position].getUrl() + position);
			// Choose an image to display based on the movie's rating rounded to a whole number

			return view;
		}
	}
}

