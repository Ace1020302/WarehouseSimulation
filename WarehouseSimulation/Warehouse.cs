using System;
namespace WarehouseSimulation
{
	public class Warehouse
	{
		List<Dock> Docks = new List<Dock>();

		Queue<Truck> Entrance
		{
			get;
			set;
		}

		public Warehouse()
		{
		}

		public void Run()
		{
			SetupSimulation();

			int i = 0;
			Console.WriteLine($"Dock {i}: {Docks[i].TotalTrucks} Trucks, {Docks[i].TotalCrates} Crates");
		}

		private void SetupSimulation()
		{
			Dock dock = new Dock();

			Crate crateOne = new Crate("U001");
            Crate crateTwo = new Crate("U002");
            Crate crateThree = new Crate("U003");
			Stack<Crate> crates = new Stack<Crate>();
			crates.Push(crateOne);
            crates.Push(crateTwo);
            crates.Push(crateThree);

			Truck truckToAdd = new Truck("Joe", "TruckTruckz", crates);

            dock.JoinLine(truckToAdd);

			Docks.Add(dock);
		}
	}
}

