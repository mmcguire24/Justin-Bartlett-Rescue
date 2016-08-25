using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Net.Http;
using System;
using HtmlAgilityPack;
using Scraper;
using DogData;
using System.Collections.Generic;
using Marcus.ListView.CustomListAdapter;
using SecondChanceResuce;
using System.Threading;
using AnimatedLoadingViews;
using AnimalRescue;
using Android.Transitions;
using System.Security.Cryptography;
using Android.Content;
using Android.Views.Animations;
using Android.Animation;

namespace SecondChanceRescue
{
	[Activity (Label = "Second Chance Rescue", MainLauncher = true, Icon = "@mipmap/sclogo")]
	public class MainActivity : Activity
	{
		ListView LV = null;
		AnimatedCircleLoadingView loading;


		protected override void OnCreate (Bundle savedInstanceState)
		{
			
			base.OnCreate (savedInstanceState);
			SingleDog mainDog = new SingleDog ();
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			//var slide = TransitionInflater.From (this).InflateTransition (Resource.Transition.explode);

			LV = FindViewById<ListView> (Resource.Id.mainlistview);
			LV.SetBackgroundColor (Color.Wheat);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {

				loading = FindViewById<AnimatedCircleLoadingView> (Resource.Id.circle_loading_view);
				var loadgif = FindViewById<RelativeLayout> (Resource.Id.loadingPanel);
				loadgif.Visibility = Android.Views.ViewStates.Visible;
				//Console.Out.WriteLine(loading.Animation);
				try{
					loading.ResetLoading();
				}
				catch{}
				loading.StartIndeterminate();
				//loading.StopOk();
				//Petstuff pet = new Petstuff("dog");
				DataApi dogApi = new DataApi(this,"dog");
				Dog initial = new Dog();
				List<Dog> doglist = new List<Dog>();
				//ThreadPool.QueueUserWorkItem (o => dogApi = new DataApi(this,"dog"));
				//doglist = dogApi.getData();
				ThreadPool.QueueUserWorkItem (o => doglist = dogApi.getData());
				//loading.StopFailure();

				LV.Visibility = Android.Views.ViewStates.Gone;
				loading.Visibility = Android.Views.ViewStates.Gone;
				//loadgif.Visibility = Android.v
				//TODO: reset to loading screen






			};

			Button catbutton = FindViewById<Button> (Resource.Id.catButton);

			catbutton.Click += delegate {

				loading = FindViewById<AnimatedCircleLoadingView> (Resource.Id.circle_loading_view);

				//Petstuff pet = new Petstuff("dog");
				DataApi dogApi = new DataApi(this,"cat");
				SingleDogScraper dogScraper = new SingleDogScraper("9591412");

				//ThreadPool.QueueUserWorkItem (o => dogApi = new DataApi(this,"dog"));


				//ThreadPool.QueueUserWorkItem (o => dogApi.getData());

				//OverridePendingTransition(Resource.Animation., Resource.Animation.abc_popup_exit);


			};
		}
		private void setupWindowAnimations() {
			var slide = TransitionInflater.From (this).InflateTransition (Resource.Transition.slide_and_changebounds);
			//Explode slide = new Explode();
			//slide.SetDuration (10000);
			//this.Window.ExitTransition.SetDuration (2000);
			this.Window.ExitTransition = slide;
			//this.Window.ExitTransition.
		}
			
	}
}


