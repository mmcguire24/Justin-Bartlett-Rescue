using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using DogData;

namespace AnimalRescue
{
	public class SingleDogScraper
	{
		public string Id { get; set;}
		public Dog detailDog { get; set;}
		string color;
		string status;
		string age;
		string microchipped;
		public string link;
		string description;
		public SingleDogScraper (string constructId)
		{
			Id = constructId;
			GetMainList (Id).Wait ();
		}

		public async Task GetMainList(string Id)
		{
			HttpClient mainListClient = new HttpClient();
			string ListUri =("http://www.justinbartlettanimalrescue.org/animals/detail?AnimalID=");
			string dogListUri = ListUri + Id;


			Console.WriteLine ("Stating html");
			string dogListAnswer = await mainListClient.GetStringAsync(dogListUri).ConfigureAwait(false);
			Console.WriteLine ("end html");
			ProcessHtml (dogListAnswer);
		}

		public void ProcessHtml(string answer)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(answer);
			var div = doc.GetElementbyId ("fieldStatus");
			 status = div.ChildNodes [1].InnerText;

			try{
		 	div = doc.GetElementbyId ("fieldGeneralColor");
			color = div.ChildNodes[1].InnerText;
			}
			catch{
			}
			try {
				div = doc.GetElementbyId ("fieldColor");
				 color = div.ChildNodes[1].InnerText;
			}
			catch{
			}
			try{
				div = doc.GetElementbyId ("fieldStatus");
				color = "Unknown";
			}
			catch{
			}
			div = div.ParentNode;
			try{
			div = div.ChildNodes [9];
			age = div.ChildNodes [1].InnerText;
			}
			catch{
			}
			try{
				div = doc.GetElementbyId ("fieldStatus").ParentNode;
				div = div.ChildNodes [8];
				age = div.ChildNodes [1].InnerText;
			}
			catch{
			}
			try{
				div = doc.GetElementbyId ("fieldStatus").ParentNode;
				div = div.ChildNodes [7];
				age = div.ChildNodes [1].InnerText;
			}
			catch{
			}

			try{
			div = doc.GetElementbyId ("fieldMicrochipped");
			microchipped = div.ChildNodes [1].InnerText;
			}catch {
				microchipped = "Unknown";
			}
			try{
			div = doc.GetElementbyId ("description");
			description = div.InnerText;
			Console.WriteLine (description);
			}
			catch{
			}

			try{
				var linkIndex = answer.IndexOf("https://s3.amazonaws.com/filestore.rescuegroups.org/5275/pictures/animals/");
				int Endlink  = answer.IndexOf (".jpg\"");
				int linklen = (Endlink + 4) - linkIndex;
				link = answer.Substring(linkIndex,linklen);
			}
			catch{
			}

			//detailDog.Microchipped = microchipped;
			//detailDog.Description = description;
			//detailDog.Color = color;
			//detailDog.Age = age;
		}

	}
}

