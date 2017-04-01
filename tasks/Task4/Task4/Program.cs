using System;
using System.IO;
using Newtonsoft.Json;

namespace Task4
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			double LitersAlc = 0;
			double LitersNAlc = 0;
			var drinksImported = new IDrink[4];
			var drinks = new IDrink[4];
			drinks[0] = new Bier(Bier.Brands.Gösser, Bier.Sizes.Mass);
			drinks[1] = new SoftDrink("Cola", 0.5);
			drinks[2] = new Bier(Bier.Brands.Puntigamer, Bier.Sizes.Krügerl);
			drinks[3] = new SoftDrink("Apfelsaft", 0.3);
			string json;

			using (StreamWriter file = File.CreateText(@"data.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(file, drinks);
			}

			using (StreamReader file = File.OpenText(@"data.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				drinksImported = (IDrink[])serializer.Deserialize(file, typeof(SoftDrink[]));
			}

			Console.WriteLine("JSON:");
			using (StreamReader file = File.OpenText(@"data.json"))
			{
				Console.WriteLine(file.ReadToEnd());
			}

			Console.WriteLine();
			Console.WriteLine("Ordered drinks:");
			foreach (IDrink drink in drinksImported)
			{
				Console.WriteLine(drink.Name + " " + drink.Size + "l");
				if (drink.IsAlcoholic)
					LitersAlc += drink.Size;
				else
					LitersNAlc += drink.Size;
			}
			Console.WriteLine("\nLiters of alcoholic drinks consumed: " + LitersAlc);
			Console.WriteLine("Liters of non-alcoholic drinks consumed: " + LitersNAlc);
		}
	}
}