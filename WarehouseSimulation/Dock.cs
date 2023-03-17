using System;
namespace WarehouseSimulation
{
	public class Dock
	{
		string Id;

		Queue<Truck> Line = new Queue<Truck>();

		double TotalSales;

		public int TotalCrates
		{
			get
			{
                int x = 0;
				for (int i = 0; i < Line.Count(); i++)
					x += Line.ElementAt(i).GetNumberOfCrates();
				return x;
			}
        }

		public int TotalTrucks => Line.Count();

		int TimeInUse;
		int TimeNotInUse;

		public Dock()
		{

		}

		public void JoinLine(Truck truck)
		{
			//Truck newTruck = ;
			//Line.Enqueue(new Truck("joe", "truckTruckz", new Stack<Crate>()));
			Line.Enqueue(truck);
		}

		Truck sendOff()
		{
			return Line.Dequeue();
		}
	}
}

