namespace WarehouseSimulation;
class Program
{
    static void Main(string[] args)
    {
        int numOfDocks = 15;
        (new Warehouse(numOfDocks)).Run();

        Console.ReadLine();
    }
}

