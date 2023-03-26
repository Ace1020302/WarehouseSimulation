///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Warehouse Project 3
// Description: Class that outlines a crate for the simulation.
//
///////////////////////////////////////////////////////////////////////////////

using System;
namespace WarehouseSimulation
{
	public class Crate
	{
		static int numOfCratesCreated = 0;

		public string Id { get; private set; }

		private double price;
		public double Price
		{
			get => price;
			set => price = Math.Max(50, value);
		}

		/// <summary>
		/// Constructor for a crate. Randomizes the crates price.
		/// </summary>
		public Crate()
		{
            numOfCratesCreated++;
			Id = $"C{ $"{numOfCratesCreated}".PadLeft(3,'0') }";
			Price = (new Random()).NextDouble() * 500;
		}

        /// <summary>
        /// Convert info of the Crate into a readable format.
        /// </summary>
        /// <returns> Returns info of the crate as a string </returns>
        public override string ToString()
        {
            double priceRounded = Math.Round(Price, 2);
			string infoToOutput = string.Empty;
            infoToOutput += $"Crate ID: {Id},";
            infoToOutput += $"Crate Value: ${priceRounded}";
            return infoToOutput;
        }

		/// <summary>
		/// resets the crates static values.
		/// </summary>
		public static void Reset()
		{
			numOfCratesCreated = 0;
		}
    }
}

