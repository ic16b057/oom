using System;

namespace Task3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var drinks = new IDrink[4];

			drinks[0] = new Bier(Bier.Brands.Gösser, Bier.Sizes.Mass);
			drinks[1] = new SoftDrink("Cola", 0.5);
			drinks[2] = new Bier(Bier.Brands.Puntigamer, Bier.Sizes.Krügerl);
			drinks[3] = new SoftDrink("Apfelsaft", 0.3);

			double LitersAlc = 0;
			double LitersNAlc = 0;

			Console.WriteLine("Ordered drinks:");
			foreach (IDrink drink in drinks)
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