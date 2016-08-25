using System;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Collections.Generic;
using DogData;
using System.Net;
using System.IO;
using Android.Media;
using Java.Security;
using System.Threading;
using Javax.Xml.Namespace;
using Android.App;

namespace Scraper
{
	public class Petstuff
	{
		public List <string> dataToAdd = new List<string> {"animalName","animalRescueId","animalSpecies","animalBreed","animalSex","animalPotentialSize","animalGeneralPotentialSize","animalAge","animalActivityLevel","animalIndoororOutdoor","animalGoodwithDogs","animalGoodwithCats","animalGoodwithKids","animalHousetrained","animalMicrochipped"};
		public List <string> dogData = new List <string>() ;
		public List <string> picUrls = new List<string>();
		public List <string> names = new List<string>();
		public List <string> breeds = new List<string>();
		public List <string> ids = new List<string>();

		string imgSrc { get; set;}

		public Petstuff (string animal)
		{
			//RunAsync ().Wait ();
			GetMainList (animal).Wait ();
		}
			

		public async Task RunAsync()
		{
			HttpClient Client = new HttpClient();
			Uri petUri = new Uri("http://www.asecondchancerescue.org/animals/detail?AnimalID=9534692");
			string spetUri =("http://www.asecondchancerescue.org/animals/detail?AnimalID=9534692");

			Console.WriteLine ("Stating html");
			string answer = await Client.GetStringAsync(spetUri).ConfigureAwait(false);
			Console.WriteLine ("end html");
			ProcessHtml (answer);



		}

		public async Task GetMainList(string animal)
		{
			HttpClient mainListClient = new HttpClient();
			string ListUri =("http://www.justinbartlettanimalrescue.org/animals/list?Species=");
			string dogListUri = ListUri + animal;


			Console.WriteLine ("Stating html");
			string dogListAnswer = await mainListClient.GetStringAsync(dogListUri).ConfigureAwait(false);
			Console.WriteLine ("end html");
			ProcessListPage (dogListAnswer);
		}

		public void ProcessHtml(string answer)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(answer);
			foreach (string dataName in dataToAdd) {


				var name = doc.GetElementbyId (dataName);
				var tex = name.ChildNodes;
				var text = tex [1];
				Console.WriteLine ("Button:Button");
				dogData.Add (text.InnerText);
			}

			var descriptionNode = doc.GetElementbyId ("animalDescription");
			var children = descriptionNode.ChildNodes;
			var descriptionTextNode = children[2];
			Console.WriteLine ("Button:Button");
			dogData.Add (descriptionTextNode.InnerText);


		}

		public void ProcessListPage(string answer)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(answer);

			var div = doc.GetElementbyId ("fullSize");
			div = div.NextSibling;
			div = div.NextSibling;
			div = div.NextSibling;
			div = div.NextSibling;
			div = div.NextSibling;
			div = div.NextSibling;
			div = div.NextSibling;
			div = div.NextSibling;

			var table = div.NextSibling;
			//var tableBody = table.Element("tbody");
			//var row = tableRow.FirstChild;
			for (int i = 3; i <  table.ChildNodes.Count;i++) 
			{
				if(i % 2 == 1)
				{
					var tableRow = table.ChildNodes [i];
					var tableData = tableRow.ChildNodes [7];
					var nameData = tableRow.ChildNodes [1];
					var link = tableData.ChildNodes [0];
					Console.WriteLine (link);
					var breedData = tableRow.ChildNodes [3];
					string breed = breedData.InnerText;
					string name = nameData.InnerText;
					string id = nameData.InnerHtml;
					id = FindIdFromHtml (id);
					Console.WriteLine (name);
					string slink = nameData.ChildNodes [1].Attributes [0].Value;

					if (link.HasChildNodes) {
						var imgNode = link.ChildNodes [0];
						 imgSrc = imgNode.Attributes [0].Value;
					}
					else
					{
						 imgSrc = "drawable/placeholder.jpg";
					}
					//name = name.Remove ((name.Length - 7), 7);
					//name = name.Remove (0, 7);

					ids.Add (id);
					picUrls.Add (imgSrc);
					names.Add (name);
					breeds.Add (breed);
					Console.WriteLine (imgSrc);
				}

			}
			//Console.WriteLine (imgSrc);


			//imgSrc = "http://orig10.deviantart.net/9557/f/2015/060/6/4/profile_picture_by_raiskream-d8k32bo.jpg";
			//File dataDir = context.getFilesDir();






		}

		private string FindIdFromHtml(string id)
		{
			int count = 0;
			string res = "";
			foreach (char letter in id) {
				if (count == 3 && letter != (char)39) {
					res += letter;
				}
				if (letter == '=' || letter == (char)39) {
					count += 1;
				}
			}
			return res;
		}
	}
}

