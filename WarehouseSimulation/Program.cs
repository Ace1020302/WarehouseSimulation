using System.Text.RegularExpressions;

namespace WarehouseSimulation;


class Program
{
    static void Main(string[] args)
    {
        CSVWriter.prepLogFile();

        int numOfDocks = 15;
        (new Warehouse(numOfDocks)).Run();

        Console.ReadLine();
    }

    
}

