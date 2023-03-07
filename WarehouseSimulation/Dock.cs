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

		Queue<Truck> Line
		{
			get;
			set;
		}

		double TotalSales
		{
			get;
			set;
		}

		int TotalCrates
		{
			get;
			set;
		}

		int TotalTrucks
		{
			get;
			set;
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

		void JoinLine(Truck truck)
		{

		}

		Truck sendOff()
		{
			return Line.Dequeue();
		}
	}
}

