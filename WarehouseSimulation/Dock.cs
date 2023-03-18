using System;
namespace WarehouseSimulation
{
	public class Dock
	{
        static int IdNum = 0;

        string id;

        Queue<Truck> Line = new Queue<Truck>();

		double TotalSales;

		public int TotalCrates
		{
			get { return Crates.Count(); }
		}

		private Stack<Crate> Crates = new Stack<Crate>();
		
		public int TotalTrucks => Line.Count();

		int TimeInUse = 0;
		int timeNotInUse = 0;

		public int TimeNotInUse
		{
			get => timeNotInUse;
			// Total time (48 increments) - the time that it was being used.
			set => timeNotInUse = 48 - TimeInUse;
		}

		public Dock()
		{
            IdNum++;
            id = idToString();
        }

        private string idToString()
        {
			//string idString = $"{IdNum}".PadLeft(2, '0');
			//return $"{idString}";
			return $"{IdNum}";
        }

		
        public void JoinLine(Truck truck)
		{
			Line.Enqueue(truck);
		}


		public void DoCurrentTruckAction()
		{
			// stops it from doing anything if nothing needs to happen.
			if (TotalTrucks == 0)
				return;

			Truck currentTruck = Line.Peek();
			if (currentTruck.GetNumberOfCrates > 0)
				Crates.Push(currentTruck.Unload);
			else
				sendOff();

			incrementTimeInUse;
		}

		private Truck sendOff()
		{
			return Line.Dequeue();
		}

		public void incrementTimeInUse() => TimeInUse++;

		// Testing method -- remove
		private void TotalCratesIncludingTrucks()
		{
            int x = 0;
            for (int i = 0; i < Line.Count(); i++)
                x += Line.ElementAt(i).GetNumberOfCrates();
            return x;
        }

        public override string ToString()
        {
            return $"Dock {id}: {TotalTrucks} Trucks, {TotalCrates} Crates";
        }
    }
}

