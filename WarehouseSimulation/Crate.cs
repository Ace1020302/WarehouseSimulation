using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		string Id;

		double Price
		{
			get => this.Price;
			set => Math.Min(50, value);
		}

		public Crate(string id)
		{
			this.Id = id;
			this.Price = (new Random()).NextDouble() * 500;
		}

        public override string ToString()
        {
            return $"Crate {Id}: ${Price}";
        }
    }
}

