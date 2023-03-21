using System;
namespace WarehouseSimulation
{
	public class Warehouse
	{
        // max of 15
		List<Dock> Docks = new List<Dock>();

		Queue<Truck> Entrance = new Queue<Truck>();

		public void Run()
		{
			SetupSimulation(1, 0);

            Random rand = new Random((int) GlobalEnum.SEED_FOR_RANDOM);
            int timeWindows = (int) GlobalEnum.TIME_INCREMENTS;
			int totalAdds = 0;
			while (timeWindows > 0)
			{
				Console.WriteLine("\n--------------- Time Increment: " + ((int)GlobalEnum.TIME_INCREMENTS - timeWindows) + "-------------------\n");
                // Trucks arrive at random to the entrance over the course of the simulation.

                // Everytime increment, trucks might show up. 50/50 chance each increment
                if (rand.Next(2) == 0)
				{
					int trucksToAdd = rand.Next(3) + 1;
                    // 1 - 4 trucks will be added at random.
                    AddTrucks(trucksToAdd);
					totalAdds += trucksToAdd;
                    Console.WriteLine($"{trucksToAdd} Trucks showed up.");
                }

                // For each time increment, or loop in this while, a single truck can enter a dock.
                if (Entrance.Count > 0)
                {
                    // finds the best dock to add the crate to. If none are free, open a new dock and make that one the optimal one.
                    Dock OptimalDock = Docks[0];
                    for (int i = 1; i < Docks.Count(); i++)
                    {
                        if (Docks[i].TotalTrucks <= OptimalDock.TotalTrucks)
                            OptimalDock = Docks[i];
                    }

                    if (OptimalDock.TotalTrucks > 0 && Docks.Count() < 15)
                    {     
                            OptimalDock = new Dock();
                            Docks.Add(OptimalDock);
                            Console.WriteLine("A new Dock Opened");
                    }

                    OptimalDock.JoinLine(Entrance.Dequeue());
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


                //Thread.Sleep(500);

                timeWindows--;
            }

            Console.WriteLine("\n\n============================================================\n");

            // Each dock costs 100 for every time increment
            int totalHoursOfOperation = 0;
			double totalEarnings = 0;

			foreach(Dock dock in Docks)
			{
                Console.WriteLine(dock);
                Console.WriteLine("\t" + dock.TimeInUse + " hours");
                totalEarnings += dock.TotalSales;
				totalHoursOfOperation += dock.TimeInUse;
            }
			int totalCost = totalHoursOfOperation * 100;
			double totalProfit = totalEarnings - totalCost;
            totalProfit = Math.Round(totalProfit, 2);
            totalEarnings = Math.Round(totalEarnings, 2);
			Console.WriteLine("\n\n============================================================\n");
            Console.WriteLine($"Dock Info:\n\t{totalAdds} trucks entered the warehouse\n\t{Docks.Count()} Docks were used\nFinances:\n\t${totalCost} spent\n\t${totalEarnings} earned\n\t${totalProfit} profit");
            
        }

        /// <summary>
        /// Sets up the properties to be ready for the simulation's execution.
        /// </summary>
        /// <param name="amtOfDocks"> The number of docks that the simulation starts with </param>
        /// <param name="amtOfTrucks"> The number of trucks that the simulation starts with </param>
        private void SetupSimulation(int amtOfDocks=15, int amtOfTrucks=100)
		{
			for (int i = 0; i < amtOfDocks; i++)
				Docks.Add(new Dock());

			for (int i = 0; i < amtOfTrucks; i++)
				Entrance.Enqueue(TruckFactory.GetRandomTruck());
		}

        /// <summary>
        /// Adds a truck to the entrance of the warehouse
        /// </summary>
        /// <param name="amt"> The amount of trucks to add </param>
		private void AddTrucks(int amt)
		{
            for (int i = 0; i < amt; i++)
                Entrance.Enqueue(TruckFactory.GetRandomTruck());
        }
	}
}

