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
		public void DoCurrentTruckAction()
		{
            // stops it from doing anything if nothing needs to happen.
			if (TotalTrucks == 0)
				return;

            Truck currentTruck = Line.Peek();
			if (currentTruck.GetNumberOfCrates() > 0)
				Crates.Push(currentTruck.Unload());
			else
				sendOff();

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

