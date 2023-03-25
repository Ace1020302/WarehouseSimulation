using System;
namespace WarehouseSimulation
{
	public class Output
	{
        public static List<Dock> docks { get; set; }

		public string outputAnInteration(int timeInc, List<Dock> docks, Dock optimalDock, List<Truck> trucksAtEntrance, Truck currentTruck)
		{
            string fancyString = String.Empty;
            fancyString += "=======================================\n";

            fancyString += $"Trucks {trucksAtEntrance.Count}:\t\t";
            foreach (Dock dock in docks)
                fancyString += $"{dock.ToString}\n";

            fancyString += "=======================================";
            return fancyString;
		}
	}
}

