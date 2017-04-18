using System;

namespace Task4
{
	public interface IDrink
	{
		/// <summary>
		/// Name of the drink
		/// </summary>
		/// <value>The name</value>
		string Name { get; }

		/// <summary>
		/// Is drink alcoholic?
		/// </summary>
		/// <value><c>true</c> if is alcoholic; otherwise, <c>false</c>.</value>
		bool IsAlcoholic { get; }

		/// <summary>
		/// Gets the size of the drink
		/// </summary>
		/// <value>The size in liters.</value>
		double Size { get; } 
	}
}
