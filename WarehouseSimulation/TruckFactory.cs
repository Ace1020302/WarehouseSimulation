using System;
namespace WarehouseSimulation
{
	public static class TruckFactory
	{
        readonly static string[] names = { "Albert", "Aaron", "Brandon", "Brant", "Baldwin", "Charlie", "Carlos", "Caroline", "Christine", "Desmond", "Drake", "Diana", "Edwin", "Edward", "Emma", "Grace", "Gary", "Jennifer", "Jackson", "Levi", "Phil", "Phyllis", "Tracy", "Woody", "Roman", "Rose", "Zach" };
		readonly static string[] companies = { "Truck Trackz", "B-its", "Truck and Trailer Inc.", "Christof's Trucks", "Transport Co.", "Z-Speed Transportation", "Speed Depot" };
		static Random randomizer = new Random((int)GlobalEnum.SEED_FOR_RANDOM);


		/// <summary>
		/// Returns a truck with a randomized properties and 1-5 crates.
		/// </summary>
		/// <returns></returns>
        public static Truck GetRandomTruck()
		{
			string driver = names[randomizer.Next(names.Length - 1)];
			string company = companies[randomizer.Next(companies.Length-1)];
			Stack<Crate> crates = new Stack<Crate>();
			for (int i = 0; i < randomizer.Next(1, 30); i++)
				crates.Push(new Crate());
            return new Truck(driver, company, crates);
		}
	}
}

