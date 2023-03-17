using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		string Id;

		double Price;

		public Crate(string id)
		{
			this.Id = id;
			this.Price = (new Random()).NextDouble() * 500;
		}
	}
}

