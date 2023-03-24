using System;
namespace WarehouseSimulation
{
	public class Truck
	{
        string driver;

        string deliveryCompany;

        // Keeps track of unloaded crates
        public static int numOfUnloads = 0;

        Stack<Crate> Trailer;

        public Truck(string driver, string deliveryCompany, Stack<Crate> trailer)
        {
            this.driver = driver;
            this.deliveryCompany = deliveryCompany;
            this.Trailer = trailer;
        }

        /// <summary>
        /// Determines if the trailer is empty.
        /// </summary>
        /// <returns> Returns true if trailer has no more crates, false if there are more. </returns>
        public bool IsTrailerEmpty() => (Trailer.Count() == 0);

        /// <summary>
        /// Loads a crate onto the Truck
        /// </summary>
        /// <param name="crate"> Crate being loaded onto Truck </param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        /// <summary>
        /// Unloads a crate from the Truck.
        /// </summary>
        /// <returns> The Crate being unloaded </returns>
        public Crate Unload()
        {
            Crate crateBeingPopped = Trailer.Pop();
            Warehouse.CrateValues.Add(crateBeingPopped.Price);
            numOfUnloads++;
            return crateBeingPopped;
        }

        /// <summary>
        /// Gets number of crates on the truck
        /// </summary>
        /// <returns> Integer representing number of crates on the truck </returns>
        public int GetNumberOfCrates() => Trailer.Count();

        public override string ToString() => $"Driver: {driver},Company: {deliveryCompany}";
        
    }
}

