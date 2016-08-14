
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
using Android.Transitions;
using DogData;

namespace AnimalRescue
{
	[Activity (Label = "SingleDogActivity")]			
	public class SingleDogActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.SingleDog);
			SingleDog mainDogPasser = new SingleDog();
			Dog mainDog = mainDogPasser.getDog ();
			TextView dogName = FindViewById<TextView> (Resource.Id.dogName);
			dogName.Text = mainDog.Name;


			// Create your application here
		}

		private void setupWindowAnimations() {
			Explode slide = new Explode();
			slide.SetDuration (10000);
			this.Window.EnterTransition.SetDuration (5000);
			this.Window.EnterTransition = slide;
		}
	}
}

