using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		static int numOfCratesCreated = 0;

		public string Id { get; private set; }

		private double price;
		public double Price
		{
			get => price;
			set => price = Math.Max(50, value);
		}

		public Crate()
		{
            numOfCratesCreated++;
			Id = idToString();
			Price = (new Random()).NextDouble() * 500;
		}

		/// <summary>
		/// Converts the id number to a padded string lead with a capital C.
		/// </summary>
		/// <returns> Returns a string </returns>
		private string idToString()
		{
			string idString = $"{numOfCratesCreated}".PadLeft(3, '0');
			return $"C{idString}";
		}

        public override string ToString()
        {
            double priceRounded = Math.Round(Price, 2);
			string infoToOutput = string.Empty;
            infoToOutput += $"Crate ID: {Id},";
            infoToOutput += $"Crate Value: ${priceRounded}";
            return infoToOutput;
        }
    }
}

