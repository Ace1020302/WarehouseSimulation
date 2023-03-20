using System;
namespace WarehouseSimulation
{
	public class Truck
	{
        string driver;

        string deliveryCompany;

        Stack<Crate> Trailer;

        public Truck(string driver, string deliveryCompany, Stack<Crate> trailer)
        {
            this.driver = driver;
            this.deliveryCompany = deliveryCompany;
            this.Trailer = trailer;
        }

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
            return Trailer.Pop();
        }

        /// <summary>
        /// Gets number of crates on the truck
        /// </summary>
        /// <returns> Integer representing number of crates on the truck </returns>
        public int GetNumberOfCrates() => Trailer.Count();
    }
}

