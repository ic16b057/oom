using System;
using System.Collections.Generic;

namespace Task3
{
	public class Bier : IDrink
	{
		public enum Sizes
		{
			Pfiff,
			Seiterl,
			Krügerl,
			Mass
		}

		public enum Brands
		{
			Puntigamer,
			Gösser,
			Zipfer,
			Ottakringer,
			Schwechater
		}

		private double S;

		/// <summary>
		///  Creates a new Bier object
		/// </summary>
		public Bier(Brands brand, Sizes size)
		{
			Name = Enum.GetName(typeof(Brands), brand);

			switch (size)
			{
				case Sizes.Pfiff:
					S = 0.2;
					break;
				case Sizes.Seiterl:
					S = 0.3;
					break;
				case Sizes.Krügerl:
					S = 0.5;
					break;
				case Sizes.Mass:
					S = 1;
					break;
			}

			IsAlcoholic = true;
		}

		public string Name { get; }
		public double Size => S;
		public bool IsAlcoholic { get; }
	}
}
