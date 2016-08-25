using System;
using System.Collections.Generic;

namespace DogData
{
	public class Dog
	{
		public Dog()
		{
			Console.WriteLine ("Creating Dog");
		}

		public Dog(string sname, string sbreed, string imgUrl)
		{
			Console.WriteLine ("Creating Dog");
			Breed = sbreed;
			Name = sname;
			picUrl = imgUrl;
		}

		public Dog(string sname, string sbreed, string imgUrl, string id)
		{
			Console.WriteLine ("Creating Dog");
			Breed = sbreed;
			Name = sname;
			picUrl = imgUrl;
			Id = id;
		}

		public Dog( Dog copyDog)
		{
			Name = copyDog.Name;

			Id = copyDog.Id;

			Species = copyDog.Species;

			Breed = copyDog.Breed;

			sex = copyDog.sex;

			PotentialSize = copyDog.PotentialSize;

			GeneralPotentialSize = copyDog.GeneralPotentialSize;

			Age = copyDog.Age;

			ActivityLevel = copyDog.ActivityLevel;

			IndoororOutdoor = copyDog.IndoororOutdoor;

			GoodwithDogs = copyDog.GoodwithDogs;

			GoodwithCats = copyDog.GoodwithCats;

			GoodwithKids = copyDog.GoodwithKids;

			Housetrained = copyDog.Housetrained;

			Microchipped = copyDog.Microchipped;

			Description = copyDog.Description;
		}
		
		public void FillDog (List<string> dogData)
		{
			 Name = dogData [0];

			 Id =  dogData[1];

			 Species = dogData[2];

   			 Breed = dogData[3];

			 sex = dogData[4];

			 PotentialSize = dogData[5];

			 GeneralPotentialSize = dogData[6];

			 Age = dogData[7];

			 ActivityLevel = dogData[8];

			 IndoororOutdoor = dogData[9];

			 GoodwithDogs = dogData[10];

			 GoodwithCats = dogData[11];

			 GoodwithKids = dogData[12];

			 Housetrained = dogData[13];

			 Microchipped = dogData[14];

			 Description = dogData[15];
		}

		public string Name { get; set;}

		public string Id { get; set;}

		public string Species { get; set;}

		public string Breed { get; set;}

		public string sex { get; set;}

		public string PotentialSize { get; set;}

		public string GeneralPotentialSize { get; set;}

		public string Age { get; set;}

		public string ActivityLevel { get; set;}

		public string IndoororOutdoor { get; set;}

		public string GoodwithDogs { get; set;}

		public string GoodwithCats { get; set;}

		public string GoodwithKids { get; set;}

		public string Housetrained { get; set;}

		public string Microchipped { get; set;}

		public string Description { get; set;}

		public string Color { get; set;}

		private string picUrl { get; set;}

		public void setUrl (string url)
		{
			picUrl = url;
		}

		public string getUrl ()
		{
			return picUrl;
		}
	}
}

