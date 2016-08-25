using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System;
using HtmlAgilityPack;
using Scraper;
using DogData;
using System.Collections.Generic;
using Marcus.ListView.CustomListAdapter;
using System.Threading;
using Android.Graphics;
using SecondChanceResuce;
using AnimatedLoadingViews;
using AnimalRescue;
using Java.Security;

namespace DogData
{
	public class DataApi : Activity
	{

		public DataApi ( Activity inActivity, string animal)
		{
			this.bactivity = inActivity;
			animalType = animal;

		}

		public Activity bactivity;
		public SingleDog selectedDog = new SingleDog();
		public string animalType;
		private Petstuff pet;

		public List <Dog> dogList = new List<Dog>();

		public List<Dog> getData(){
			
			pet = new Petstuff (animalType);
			Dog doggy = new Dog();
			//doggy.FillDog(pet.dogData);
			List <Dog> dogList = new List<Dog>();
			for(int i = 0; i < 30/*pet.picUrls.Count*/; i++)
			{
				Dog tempDoggy = new Dog(pet.names[i],pet.breeds[i],pet.picUrls[i], pet.ids[i]);
				dogList.Add(tempDoggy);
			}

			/*this.bactivity.SetContentView (Resource.Layout.Main);
			ListView mainList = (ListView)this.bactivity.FindViewById (Resource.Id.mainlistview);
			mainList.Adapter = new CustomListAdapter (this.bactivity, dogList);
			mainList.SetBackgroundColor (Color.AliceBlue);
			AnimatedCircleLoadingView loading;
			loading = this.bactivity.FindViewById<AnimatedCircleLoadingView> (Resource.Id.circle_loading_view);
			TextView mainText = (TextView)this.bactivity.FindViewById (Resource.Id.mainText);
			mainText.Text = dogList [0].Name;
			loading.Visibility = Android.Views.ViewStates.Gone;
			mainList.Visibility = Android.Views.ViewStates.Gone;*/

			RunOnUiThread (() => DisplayData(dogList));
			return dogList;
		}

		public void DisplayData(List<Dog> UidogList)
		{
			//this.bactivity.SetContentView (Resource.Layout.Main);
			//return;
			ListView mainList = (ListView)this.bactivity.FindViewById (Resource.Id.mainlistview);
			TextView mainText = (TextView)this.bactivity.FindViewById (Resource.Id.mainText);
			FrameLayout frameSplitter2 = (FrameLayout)this.bactivity.FindViewById (Resource.Id.frameSplitter2);
			FrameLayout frameSplitter = (FrameLayout)this.bactivity.FindViewById (Resource.Id.frameSplitter);

			mainList.Adapter = new CustomListAdapter (this.bactivity, UidogList);
			mainList.SetBackgroundColor (Color.BurlyWood);
			mainList.SetBackgroundColor (Color.CadetBlue);
			mainList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
			{
				selectedDog.clear();
				selectedDog.setDog(UidogList[e.Position]);
				mainText.Text = selectedDog.getDog().Name;
				mainList.Context.StartActivity(typeof(SingleDogActivity));
			};



			var loadgif = this.bactivity.FindViewById<RelativeLayout> (Resource.Id.loadingPanel);
			//TextView mainText = (TextView)this.bactivity.FindViewById (Resource.Id.mainText);
			//mainText.Text = UidogList [0].Name;
			loadgif.Visibility = Android.Views.ViewStates.Gone;
			frameSplitter2.Visibility = Android.Views.ViewStates.Visible;
			frameSplitter.Visibility = Android.Views.ViewStates.Gone;
			mainList.Visibility = Android.Views.ViewStates.Visible;


		}



	}
}

