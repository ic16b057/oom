using System;
using System.Collections.Generic;

namespace Task2
{
	public class Wirtshaus
	{
		public enum Size
		{
			Pfiff,
			Seiterl,
			Krügerl,
			Mass
		}

		public enum Brand
		{
			Puntigamer,
			Gösser,
			Zipfer,
			Ottakringer,
			Schwechater
		}

		/// <summary>
		/// The name of the Wirtshaus
		/// </summary>
		private string Name;

		/// <summary>
		/// List that contains a KeyValuePair of ordered beers
		/// </summary>
		private List<KeyValuePair<Brand, Size>> OrderdBeer = new List<KeyValuePair<Brand, Size>>();

		/// <summary>
		///  Creates a new Wirtshaus object
		/// </summary>
		public Wirtshaus(String name)
		{
			Name = name;
		}

		/// <summary>
		/// Total amount of ordered beer in Liters
		/// </summary>
		public double TotalAmount { get; private set; }

		/// <summary>
		/// Orders a new beer
		/// </summary>
		/// <param name="brand">The brand of the beer</param>
		/// <param name="size">The size of the beer</param>
		public void order(Brand brand, Size size)
		{
			switch (size)
			{
				case Size.Pfiff:
					TotalAmount += 0.2;
					break;
				case Size.Seiterl:
					TotalAmount += 0.3;
					break;
				case Size.Krügerl:
					TotalAmount += 0.5;
					break;
				case Size.Mass:
					TotalAmount += 1;
					break;
			}

			OrderdBeer.Add(new KeyValuePair<Brand, Size>(brand,size));
		}

		/// <summary>
		/// Gets all your orders.
		/// </summary>
		/// <value>The orders as KeyValuePair</value>
		public List<KeyValuePair<Brand, Size>> getOrders => OrderdBeer;
	}
}
