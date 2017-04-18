using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Collections.Generic;
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


			//Task6:
			var ordered = new List<IDrink>();

			var guest = new Subject<IDrink>();
			guest.Sample(TimeSpan.FromSeconds(2))
				 //.Subscribe(x => DoDrink(x));
				 //.Do(x => Console.WriteLine($"ordered {x.Name} {x.Size}"))
				 .Do(x => ordered.Add(x))
				 .Subscribe(x => Console.WriteLine($"ordered {x.Name} {x.Size}"));

			var t = new Thread(() =>
			{
				while (true)
				{
					Thread.Sleep(500);
					var bier = new Bier(RandomEnumValue<Bier.Brands>(), RandomEnumValue<Bier.Sizes>());
					guest.OnNext(bier);
					//Console.WriteLine($"sent {bier.Name} {bier.Size}");
				}
			});
			t.Start();


			var cts = new CancellationTokenSource();
			var dT = Drink(ordered, cts.Token);
		}

		public static Task DoDrink(IDrink d, CancellationToken ct)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"Drinking {d.Name} {d.Size}...");
				Task.Delay(TimeSpan.FromSeconds(d.Size)).Wait();
				return true;
			});
		}

		public static async Task Drink(List<IDrink> o, CancellationToken ct)
		{
			while (true)
			{
				foreach (IDrink d in o)
				{
					Console.WriteLine("bla");
					await DoDrink(d, ct);
					Console.WriteLine($"{d.Name} empty :(");
					o.Remove(d);
				}
				Console.WriteLine("Waiting for new beer...");
				Task.Delay(TimeSpan.FromSeconds(1)).Wait();
			}
		}

		/// <summary>
		/// Gets a random value from an enum
		/// </summary>
		/// <returns>The enum value.</returns>
		/// <typeparam name="T">The enum</typeparam>
		static T RandomEnumValue<T>()
		{
			var v = Enum.GetValues(typeof(T));
			return (T)v.GetValue(new Random().Next(v.Length));
		}
	}
}