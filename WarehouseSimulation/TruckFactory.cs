using System;
namespace WarehouseSimulation
{
	public class TruckFactory
	{
        readonly static string[] names = { "Albert", "Aaron", "Brandon", "Brant", "Baldwin", "Charlie", "Carlos", "Caroline", "Christine", "Desmond", "Drake", "Diana", "Edwin", "Edward", "Emma", "Grace", "Gary", "Jennifer", "Jackson", "Levi", "Phil", "Phyllis", "Tracy", "Woody", "Roman", "Rose", "Zach" };
		readonly static string[] companies = { "Truck Trackz", "X-its", "Truck and Trailer Inc.", "Christof's Trucks", "Transport Co.", "Z-Speed Transportation", "Speed Depot" };
		static Random randomizer = new Random();

		public static Truck GetRandomTruck()
		{
			string driver = names[randomizer.Next(names.Length - 1)];
			string company = companies[randomizer.Next(companies.Length-1)];

			return new Truck(driver, company, new Stack<Crate>());
		}
	}
}

