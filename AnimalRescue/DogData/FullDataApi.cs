using System;
using Android.App;
using DogData;

namespace SecondChanceResuce
{
	public class FullDataApi
	{
		public FullDataApi ( )
		{
			
		}

		public void getData(Activity activity, string animal)
		{

			DataApi dogApi = new DataApi (activity, animal);
			dogApi.getData ();
		}
	}
}

