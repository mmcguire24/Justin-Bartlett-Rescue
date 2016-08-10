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

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			LV = FindViewById<ListView> (Resource.Id.mainlistview);
			LV.SetBackgroundColor (Color.Wheat);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {

				loading = FindViewById<AnimatedCircleLoadingView> (Resource.Id.circle_loading_view);
				loading.StartIndeterminate();
				//Petstuff pet = new Petstuff("dog");
				DataApi dogApi = new DataApi(this,"dog");
				Dog initial = new Dog();
				List<Dog> doglist = new List<Dog>();
				//ThreadPool.QueueUserWorkItem (o => dogApi = new DataApi(this,"dog"));
				//doglist = dogApi.getData();
				ThreadPool.QueueUserWorkItem (o => doglist = dogApi.getData());
				//LV.Visibility = Android.Views.ViewStates.Visible;
				//TODO: reset to loading screen





			};

			Button catbutton = FindViewById<Button> (Resource.Id.catButton);

			catbutton.Click += delegate {

				loading = FindViewById<AnimatedCircleLoadingView> (Resource.Id.circle_loading_view);

				//Petstuff pet = new Petstuff("dog");
				DataApi dogApi = new DataApi(this,"cat");

				//ThreadPool.QueueUserWorkItem (o => dogApi = new DataApi(this,"dog"));


				ThreadPool.QueueUserWorkItem (o => dogApi.getData());



			};
		}
	}
}


