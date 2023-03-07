using System;
namespace WarehouseSimulation
{
	public class Truck
	{
        string driver
        {
            get;
            set;
        }

        string deliveryCompany
        {
            get;
            set;
        }

        Stack<Crate> Trailer
        {
            get;
            set;
        }

        public Truck(string driver, string deliveryCompany, Stack<Crate> trailer)
        {
            this.driver = driver;
            this.deliveryCompany = deliveryCompany;
            this.Trailer = trailer;
        }

        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        public Crate Unload()
        {
            return Trailer.Pop();
        }

        public int GetNumberOfCrates() => Trailer.Count();
    }
}

