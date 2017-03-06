using System;

namespace Task2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var myMensa = new Wirtshaus("Mensa");
			myMensa.order(Wirtshaus.Brand.Puntigamer, Wirtshaus.Size.Krügerl);
			myMensa.order(Wirtshaus.Brand.Gösser, Wirtshaus.Size.Mass);
			myMensa.order(Wirtshaus.Brand.Puntigamer, Wirtshaus.Size.Seiterl);
			Console.WriteLine("You ordered: ");
			foreach (var order in myMensa.getOrders)
			{
				Console.WriteLine(order.Key+" "+order.Value);
			}
			Console.WriteLine("\nYou ordered "+myMensa.TotalAmount+" liters beer!");
		}
	}
}
