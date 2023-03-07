using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		string Id
		{
			get;
			set;
		}

		double Price
		{
			get;
			set;
		}

		public Crate(string id)
		{
			this.Id = id;
			this.Price = (new Random()).NextDouble() * 500;
		}
	}
}

