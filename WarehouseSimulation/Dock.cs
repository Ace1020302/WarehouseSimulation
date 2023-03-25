using System;
namespace WarehouseSimulation
{
	public class Dock
	{
		// increments for each new dock
        static int numOfDocks = 0;

		public int longestLine { get; private set; }
		public static int totalLongestLine { get; private set; }
		public static int numOfTrucksProcessed = 0;

        string Id;

        Queue<Truck> Line = new Queue<Truck>();

		List<int> truckTotalValues = new List<int>();

		// Gets total amount of money from all the crates at the dock
		public double TotalSales
		{
			get 
			{
				//TODO: reduce to one-line?
				double sum = 0; 
				foreach (Crate crate in Crates) 
					sum += crate.Price; return sum; 
			}
		}

		// The crates in the dock (not the trucks)
		public int TotalCrates
		{
			get => Crates.Count();
		}

		private Stack<Crate> Crates = new Stack<Crate>();

		// Number of Trucks at the Dock
		public int TotalTrucks => Line.Count();

		// The amount of time the Dock has been used
		public int TimeInUse = 0;

        // The amount of time the Dock has not been used
        public int TimeNotInUse
		{
			// total time - time in use
			get => (int) GlobalEnum.TIME_INCREMENTS - TimeInUse;
		}

		public Dock()
		{
			numOfDocks++;
			longestLine = 0;
			Id = $"{numOfDocks}";
        }

		/// <summary>
		/// Adds a truck to the Dock's line.
		/// </summary>
		/// <param name="truck"> Truck being added to the line </param>
        public void JoinLine(Truck truck)
		{
			Line.Enqueue(truck);
			if (longestLine < Line.Count())
				longestLine = Line.Count();
			if (totalLongestLine < longestLine)
				totalLongestLine = longestLine;
		}


		/// <summary>
		/// Causes the current truck to either unload, or move on.
		/// </summary>
		public void DoCurrentTruckAction(int time)
		{
			// stops it from doing anything if nothing needs to happen.
			if (TotalTrucks == 0)
				return;

            string infoToOutput = $"Time: {time},";

            Truck currentTruck = Line.Peek();

			if (!currentTruck.IsTrailerEmpty())
			{
				Crate poppedCrate = currentTruck.Unload();

				infoToOutput += currentTruck.ToString() + ',';
				infoToOutput += poppedCrate.ToString() + ',';

				// check if it was the last crate. If it is, execute.
                if (currentTruck.IsTrailerEmpty())
                {
                    infoToOutput += "Crate was unloaded but the truck has no more crates to unload";
					// If the truck is empty, send it off. Say whether or not the dock is now empty
					sendOff();
					if(Line.Count() != 0)
						infoToOutput += " and another truck is already in the Dock";
					else
						infoToOutput += " and another truck is not in the Dock";  
                }
                else
                    infoToOutput += "Crate was unloaded but the truck still has more crates to unload";

				infoToOutput += ",\n";

				CSVWriter.writeToLog(infoToOutput);

				Crates.Push(poppedCrate);
			}
			
            Console.WriteLine($"Incremented time for Dock {Id} | Total: {TimeInUse} increments");
            TimeInUse++;
		}

		/// <summary>
		/// Takes a truck out of the Dock line.
		/// </summary>
		/// <returns> Returns Truck that is leaving the queue </returns>
		private Truck sendOff() {
			numOfTrucksProcessed++;
			return Line.Dequeue();
		}

		/// <summary>
		/// Convert info of the Dock into a readable format.
		/// </summary>
		/// <returns> Returns info of the dock as a string </returns>
        public override string ToString()
        {
            return $"Dock {Id}: {TotalTrucks} Trucks, {TotalCrates} Crates, {TimeInUse} time open, {TimeNotInUse} time closed";
        }
    }
}

