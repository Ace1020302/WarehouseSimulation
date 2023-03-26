///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Warehouse Project 3
// Description: Start point for the program to run. Also handles input from user and resets statics between simulations.
//
///////////////////////////////////////////////////////////////////////////////

namespace WarehouseSimulation;
class Program
{

    /// <summary>
    /// Start point for the program
    /// </summary>
    /// <param name="args"> Arguments of the program (should be empty) </param>
    static void Main(string[] args)
    {
        
        int numOfDocks = 0;
        while (numOfDocks != -1)
        {
            Console.WriteLine("Number of Docks (-1 to quit): ");
            string input = Console.ReadLine();

            try
            {
                numOfDocks = int.Parse(input);
                if (numOfDocks < 0)
                {
                    if(numOfDocks != -1)
                        Console.WriteLine("Try a different number");
                    continue;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Try a number");
                continue;
            }
            CSVWriter.prepLogFile();
            (new Warehouse(numOfDocks)).Run();
            resetStatics();

            Console.WriteLine();

        }
    }

    /// <summary>
    /// resets the static values of Dock, Truck, and Crate classes.
    /// </summary>
    private static void resetStatics()
    {
        Dock.Reset();
        Truck.Reset();
        Crate.Reset();
    }

}

