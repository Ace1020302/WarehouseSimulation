using System;
namespace WarehouseSimulation
{
	public class Dock
	{
		// increments for each new dock
        static int numOfDocks = 0;

        string Id;

        Queue<Truck> Line = new Queue<Truck>();

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
            Id = idToString(numOfDocks);
        }

        /// <summary>
		/// Converts the id to a string
		/// </summary>
		/// <param name="idNumToConvert"> Id of dock to convert</param>
		/// <returns> String g</returns>
        private string idToString(int idNumToConvert)
        {
			//string idString = $"{IdNum}".PadLeft(2, '0');
			//return $"{idString}";
			return $"{idNumToConvert}";
        }

		/// <summary>
		/// Adds a truck to the Dock's line.
		/// </summary>
		/// <param name="truck"> Truck being added to the line </param>
        public void JoinLine(Truck truck)
		{
			Line.Enqueue(truck);
		}


		/// <summary>
		/// Causes the current truck to either unload, or move on.
		/// </summary>
		public void DoCurrentTruckAction(int timeIncrement)
		{
			// stops it from doing anything if nothing needs to happen.
			if (TotalTrucks == 0)
				return;

            string infoToOutput = $"Time: {timeIncrement},";

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
						infoToOutput += "and another truck is already in the Dock";
					else
						infoToOutput += "and another truck is not in the Dock";
                    
                }
                else
                    infoToOutput += "Crate was unloaded but the truck still has more crates to unload";

				infoToOutput += ",\n";

				Console.WriteLine(infoToOutput);

				Crates.Push(poppedCrate);
			}
			
            Console.WriteLine($"Incremented time for Dock {Id} | Total: {TimeInUse} hours");
            TimeInUse++;
		}

		/// <summary>
		/// Takes a truck out of the Dock line.
		/// </summary>
		/// <returns> Returns Truck that is leaving the queue </returns>
		private Truck sendOff() => Line.Dequeue();

		// Testing method -- remove
		private int TotalCratesIncludingTrucks()
		{
            int x = 0;
            for (int i = 0; i < Line.Count(); i++)
                x += Line.ElementAt(i).GetNumberOfCrates();
            return x;
        }


        public override string ToString()
        {
            return $"Dock {Id}: {TotalTrucks} Trucks, {TotalCrates} Crates";
        }
    }
}

