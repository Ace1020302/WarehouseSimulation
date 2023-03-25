using System.Text.RegularExpressions;

namespace WarehouseSimulation;


class Program
{
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
                Console.WriteLine("Try a different number");
                continue;
            }
            CSVWriter.prepLogFile();
            (new Warehouse(numOfDocks)).Run();
            resetStatics();

            Console.WriteLine();

        }
    }

    private static void resetStatics()
    {
        Dock.Reset();
        Truck.Reset();
        Crate.Reset();
    }

}

