using System;
namespace WarehouseSimulation
{
	public class Dock
	{
		string Id
		{
			get;
			set;
		}

		Queue<Truck> Line = new Queue<Truck>();

		double TotalSales
		{
			get;
			set;
		}

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

		public int TotalTrucks
		{
			get => Line.Count();
		}

		int TimeInUse
		{
			get;
			set;
		}

		int TimeNotInUse
		{
			get;
			set;
		}

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

