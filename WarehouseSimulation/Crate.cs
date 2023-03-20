using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		static int IdNum = 0;

		string Id;

		private double price;
		public double Price
		{
			get => price;
			set => price = Math.Max(50, value);
		}

		public Crate()
		{
			IdNum++;
			Id = idToString();
			Price = (new Random()).NextDouble() * 500;
		}

		/// <summary>
		/// Converts the id number to a padded string lead with a capital C.
		/// </summary>
		/// <returns> Returns a string </returns>
		private string idToString()
		{
			string idString = $"{IdNum}".PadLeft(3, '0');
			return $"C{idString}";
		}

        public override string ToString()
        {
            double priceRounded = Math.Round(Price, 2);
            return $"Crate {Id}: ${priceRounded}";
        }
    }
}

