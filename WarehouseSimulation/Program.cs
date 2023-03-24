using System.Text.RegularExpressions;

namespace WarehouseSimulation;


class Program
{
    static void Main(string[] args)
    {
        prepLogFile();

        int numOfDocks = 15;
        (new Warehouse(numOfDocks)).Run();

        Console.ReadLine();
    }

    private static void prepLogFile()
    {
        string[] files = Directory.GetFiles("../../../Logs");
        string pattern = @"\d+";

        int highestValue = 0;
        foreach (string fileName in files) {
            string matchValue = Regex.Match(fileName, pattern).Value;
            int currentValue = int.Parse(matchValue);
            if (highestValue < currentValue)
                highestValue = currentValue;
        }

        File.Create($"../../../Logs/test{highestValue+1}.csv");  
    }
}

