using System;
namespace WarehouseSimulation
{
	public class Dock
	{
        static int IdNum = 0;

        string id;

        Queue<Truck> Line = new Queue<Truck>();

		public double TotalSales
		{
			get 
			{ 
				double sum = 0; 
				foreach (Crate crate in Crates) 
					sum += crate.Price; return sum; 
			}
		}

		public int TotalCrates
		{
			get { return Crates.Count(); }
		}

		private Stack<Crate> Crates = new Stack<Crate>();
		
		public int TotalTrucks => Line.Count();

		public int TimeInUse = 0;

		public int TimeNotInUse
		{
			get => 48 - TimeInUse;
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
			if (currentTruck.GetNumberOfCrates() > 0)
				Crates.Push(currentTruck.Unload());
			else
				sendOff();

            Console.WriteLine($"Incremented time for Dock {id} | Total: {TimeInUse} hours");
            TimeInUse++;
		}

		private Truck sendOff()
		{
			return Line.Dequeue();
		}

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
            return $"Dock {id}: {TotalTrucks} Trucks, {TotalCrates} Crates";
        }
    }
}

