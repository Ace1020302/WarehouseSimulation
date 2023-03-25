using System;
namespace WarehouseSimulation
{
	public class Warehouse
	{
        // max of 15
		List<Dock> Docks = new List<Dock>();

		Queue<Truck> Entrance = new Queue<Truck>();

        Random rand = new Random();

        public Warehouse(int amtOfDocks=0)
        {
            SetupSimulation(amtOfDocks);
        }

		public void Run()
		{
            int time = 0;
			int totalAmtOfTrucksIntroduced = 0;

			while (time < (int) GlobalEnum.TIME_INCREMENTS)
			{
				Console.WriteLine("\n--------------- Time Increment: " + time + "-------------------\n");
                // Trucks arrive at random to the entrance over the course of the simulation.

                // Introduces Trucks and adds them to the total
                totalAmtOfTrucksIntroduced += IntroduceTrucks(time);

                // For each time increment, or loop in this while, a single truck can enter a dock.
                if (Entrance.Count > 0)
                {
                    // finds the best dock to add the crate to. If none are free, open a new dock and make that one the optimal one.
                    Dock OptimalDock = Docks[0];

                    for (int i = 1; i < Docks.Count(); i++)
                    {
                        if (Docks[i].TotalTrucks < OptimalDock.TotalTrucks)
                            OptimalDock = Docks[i];
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
                    currentDock.DoCurrentTruckAction(time);
                }


                //Thread.Sleep(500);

                time++;
            }

            Console.WriteLine("\n\n============================================================\n");

           

            // Each dock costs 100 for every time increment
            int totalTimeOfOperation = 0;
			double totalEarnings = 0;

            int docksUsed = 0;

            int totalAmountOfCrates = 0;
			foreach(Dock dock in Docks)
			{
                if (dock.TimeInUse != 0)
                    docksUsed++;
                totalEarnings += dock.TotalSales;
                totalTimeOfOperation += dock.TimeInUse;
                totalAmountOfCrates += dock.TotalCrates;
            }
			int totalCost = totalTimeOfOperation * 100;
			double totalProfit = totalEarnings - totalCost;

            // Calculate averages
            double avgValOfCrates = totalEarnings / Truck.numOfUnloads;
            double avgValOfTrucks = totalEarnings / Dock.numOfTrucksProcessed;

            int avgTimeADockWasUsed = totalTimeOfOperation/Docks.Count();

            avgValOfCrates = Math.Round(avgValOfCrates, 2);
            avgValOfTrucks = Math.Round(avgValOfTrucks, 2);
            totalProfit = Math.Round(totalProfit, 2);
            totalEarnings = Math.Round(totalEarnings, 2);

            Console.WriteLine($"Dock Info: ");
           
            
            Console.WriteLine($"\t{totalAmtOfTrucksIntroduced} trucks entered the warehouse");
            Console.WriteLine($"\t{docksUsed} out of {Docks.Count()} Docks were used");
            Console.WriteLine($"\tLongest Line Length: {Dock.totalLongestLine}");

            Console.WriteLine("Individual Dock Info:");

            foreach (Dock dock in Docks)
            {
                Console.WriteLine($"\t{dock}");
            }

            Console.WriteLine("Overall Info:");
            Console.WriteLine($"\tTotal Trucks Processed: {Dock.numOfTrucksProcessed}\n\tTotal Crate Count: {totalAmountOfCrates}");
            Console.WriteLine($"\tAverage Value of Crates: {avgValOfCrates}");
            Console.WriteLine($"\tAverage Value of Trucks: {avgValOfTrucks}");
            Console.WriteLine($"\tAverage Time a Dock was in Use: {avgTimeADockWasUsed} increments");
            Console.WriteLine($"Finances:\n\t${totalCost} spent\n\t${totalEarnings} earned\n\t${totalProfit} profit");

        }


        /// <summary>
        /// Introduces trucks to the entrance line based on time of day.
        /// </summary>
        /// <param name="time"> The time of the day (indicated in 10 minute increments i.e 4 = 40 minutes) </param>
        /// <returns> The amount of trucks added to the Entrance (int) </returns>
        private int IntroduceTrucks(int time)
        {
            int trucksToAdd = 0;
            // Checks first two hours and the second two hours assuming 10 minute increments
            bool isNoon = (time > 12 & time < ((int)GlobalEnum.TIME_INCREMENTS - 12));

            // Modifer for chance of it happening.Increases to 1.5 if in Noon.
            double randModifer = 1;
            Random rand = new Random();
            int chanceOfIntroducing = (int)(rand.NextDouble() * 100);
            if (isNoon)
                randModifer = 1.5;
            chanceOfIntroducing *= (int) randModifer;

            
            if (chanceOfIntroducing >= 50)
            {
                if (isNoon)
                {
                    trucksToAdd = rand.Next(20) + 1;
                    // 1 - 20 trucks will be added at random.
                    AddTrucks(trucksToAdd);
                }
                else
                {
                    trucksToAdd = rand.Next(10) + 1;
                    // 1 - 10 tucks will be added at random.
                    AddTrucks(trucksToAdd);
                }
            }
            return trucksToAdd;
        }


        /// <summary>
        /// Sets up the properties to be ready for the simulation's execution.
        /// </summary>
        /// <param name="amtOfDocks"> The number of docks that the simulation starts with </param>
        /// <param name="amtOfTrucks"> The number of trucks that the simulation starts with </param>
        private void SetupSimulation(int amtOfDocks=15)
		{
			for (int i = 0; i < amtOfDocks; i++)
				Docks.Add(new Dock());
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

