using System;
namespace WarehouseSimulation
{
	public class Warehouse
	{
		List<Dock> Docks = new List<Dock>();

		Queue<Truck> Entrance = new Queue<Truck>();

		public Warehouse()
		{
		}

		public void Run()
		{
			SetupSimulation();

			Random rand = new Random(10005);
			int timeWindows = 48;
			Dock tempDock;

			while (timeWindows >= 0)
			{
				// for each time increment, or loop in this while, a truck can enter a dock.
				// For each truck, a single crate can be unloaded each time increment.
				// For each dock.

				// Trucks immediately swap out if there is another at the dock. No time increment decrease.
				// Each dock costs 100 for every time increment
				// Trucks arrive at random to the entrance over the course of the simulation.

				tempDock = Docks[rand.Next(Docks.Count())];
				for (int i = 0; i < rand.Next(Entrance.Count()); i++)
					tempDock.JoinLine(Entrance.Dequeue());

				// Console.WriteLine(tempDock);
				timeWindows--;
            }

			//foreach(Dock dock in Docks)
   //             Console.WriteLine(dock);
        }

		private void SetupSimulation(int amtOfDocks=15, int amtOfTrucks=100)
		{
			for (int i = 0; i < amtOfDocks; i++)
				Docks.Add(new Dock());

			for (int i = 0; i < amtOfTrucks; i++)
				Entrance.Enqueue(TruckFactory.GetRandomTruck());
		}
	}
}

