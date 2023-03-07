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

		public Crate(string id, double price)
		{
			this.Id = id;
			this.Price = price;
		}
	}
}

