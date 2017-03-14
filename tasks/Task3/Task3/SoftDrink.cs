using System;
namespace Task3
{
	public class SoftDrink: IDrink
	{
public SoftDrink(string name, double size)
		{
			Name = name;
			Size = size;

			IsAlcoholic = false;
		}

		public string Name { get; }
		public bool IsAlcoholic { get; }
		public double Size { get; }
	}
}
