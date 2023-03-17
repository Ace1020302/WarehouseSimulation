using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		static int IdNum = 0;

		string id;

		private double price;
		public double Price
		{
			get => price;
			set => price = Math.Max(50, value);
		}

		public Crate()
		{
			IdNum++;
			id = idToString();
			Price = (new Random()).NextDouble() * 500;
		}

		private string idToString()
		{
			string idString = $"{IdNum}".PadLeft(3, '0');
			return $"U{idString}";
		}
        public override string ToString()
        {
            double priceRounded = Math.Round(Price, 2);
            return $"Crate {id}: ${priceRounded}";
        }
    }
}

