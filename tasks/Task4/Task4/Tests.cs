using System;
using NUnit.Framework;

namespace Task4
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void MyTests()
		{
			var test1 = new Bier(Bier.Brands.Gösser, Bier.Sizes.Mass);
			Assert.AreEqual(test1.Size, 1.0);
			Assert.AreEqual(test1.IsAlcoholic, true);
			Assert.AreEqual(test1.Name, "Gösser");
			var test2 = new SoftDrink("Cola", 1);
			Assert.AreEqual(test2.Name, "Cola");
			Assert.AreEqual(test2.Size, 1.0);
			Assert.AreEqual(test2.IsAlcoholic, false);
			var test3 = new Bier(Bier.Brands.Ottakringer, Bier.Sizes.Krügerl);
			Assert.AreEqual(test3.Size, 0.5);
			var test4 = new Bier(Bier.Brands.Ottakringer, Bier.Sizes.Seiterl);
			Assert.AreEqual(test4.Size, 0.3);
		}
	}
}
