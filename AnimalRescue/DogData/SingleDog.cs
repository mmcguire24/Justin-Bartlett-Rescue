using System;
using Android.Views.InputMethods;
using Android.Provider;
using DogData;
using Android.Content;
using System.Runtime.CompilerServices;
using Android.App;

namespace AnimalRescue
{
	public class SingleDog
	{
		public static Dog singledoggo { get; set;}
		public static bool start = false;

		public SingleDog ()
		{
		}

		public void clear()
		{
			singledoggo = null;
		}

		public Dog getDog()
		{
			return singledoggo;
		}

		public void setDog(Dog newDog)
		{
			singledoggo = newDog;
		}

		public bool shouldStart()
		{
			return start;
		}

		public void setStart(bool should)
		{
			start = should;
		}
	}
}

