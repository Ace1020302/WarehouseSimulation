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
			SetupSimulation(10, 0);

			Random rand = new Random(10005);
			int timeWindows = 48;
			Dock openDock;

			while (timeWindows >= 0)
			{
                // Trucks arrive at random to the entrance over the course of the simulation.

                // Everytime increment, trucks might show up. 50/50 chance each increment
                if (rand.Next(1) == 1)
				{
					// 1 - 4 trucks will be added at random.
					AddTrucks(rand.Next(3) + 1);
				}

                // Interates through the docks and makes them do necessary changes
                /* For the current truck, a single crate can be unloaded each time increment.
					For each dock. */
                for (int i = 0; i < Docks.Count(); i++) 
				{
					Dock currentDock = Docks[i];
                    // Trucks immediately swap out if there is another at the dock. No time increment decrease.
                    currentDock.DoCurrentTruckAction();
                }

                // For each time increment, or loop in this while, a single truck can enter a dock.
                if (Entrance.Count > 0)
				{
					// finds the best dock to add the crate to. If none are free, open a new dock and make that one the optimal one.
					Dock OptimalDock = Docks[0];
					for(int i = 1; i < Docks.Count(); i++)
					{
						if (Docks[i].TotalTrucks <= OptimalDock.TotalTrucks)
							OptimalDock = Docks[i];
					}

					if (OptimalDock.TotalTrucks > 0)
					{
                        OptimalDock = new Dock();
						Docks.Add(OptimalDock);
                    }

					OptimalDock.JoinLine(Entrance.Dequeue());
				}

                timeWindows--;
            }

			// Each dock costs 100 for every time increment
			int totalCost = 0;
			foreach(Dock dock in Docks)
			{
                Console.WriteLine(dock);
                totalCost += 48 - dock.TimeNotInUse;
            }
			totalCost *= 100;
            Console.WriteLine(totalCost);
        }

        private void SetupSimulation(int amtOfDocks=15, int amtOfTrucks=100)
		{
			for (int i = 0; i < amtOfDocks; i++)
				Docks.Add(new Dock());

			for (int i = 0; i < amtOfTrucks; i++)
				Entrance.Enqueue(TruckFactory.GetRandomTruck());
		}

		private void AddTrucks(int amt)
		{
            for (int i = 0; i < amt; i++)
                Entrance.Enqueue(TruckFactory.GetRandomTruck());
        }
	}
}

