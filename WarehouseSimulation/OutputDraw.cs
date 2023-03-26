using System;
namespace WarehouseSimulation
{
	public class OutputDraw
	{
        public static List<Dock> docks { get; set; }
        public static int time = 0;

		public static void DrawTruckEnteringLine(int dockNum)
		{
			int truckPosition = 0;
			while(truckPosition <= dockNum)
			{
				Console.WriteLine(DrawDocksWithTruckAtPosition(truckPosition));
				truckPosition++;
				Thread.Sleep(200);
			}
			for (int i = 0; i < 4; i++)
			{
				Console.WriteLine(DrawTruckMovingForward(truckPosition, i));
                Thread.Sleep(100);
            }
		}

        public static void DrawFinal()
        {
            string outString = string.Empty;
            outString += $"=================Time:{time}==========================================\n";
            outString += "Entrance\n";
            for (int i = 0; i < docks.Count(); i++)
                    outString += $"\t\t\t\t{docks[i].iterationString()}\n";
            outString += "\t\t\t\t\t\t\t\tExit\n";
            outString += "==================================================================\n";

            Console.WriteLine(outString);
        }

        public static void DrawTruckExitingLine(int dockNum)
		{
            int truckPosition = dockNum;
            while (truckPosition < docks.Count())
            {
                Console.WriteLine(DrawDocksWithTruckAtExit(truckPosition));
                truckPosition++;
                Thread.Sleep(100);
            }
		}

        public static string DrawDocksWithTruckAtExit(int truckPosition)
        {
            string outString = string.Empty;
            outString += $"=================Time:{time}==========================================\n";
            outString += "Entrance\n";
            for (int i = 0; i < docks.Count(); i++)
            {
                if (truckPosition == i)
                {
                    outString += $"\t\t\t\t{docks[i].iterationString()}\t|_|_>";
                }
                else
                {
                    outString += $"\t\t\t\t{docks[i].iterationString()}";
                }
                outString += "\n";
            }
            outString += "\t\t\t\t\t\t\t\tExit\n";
            outString += "==================================================================\n";
            
            return outString;
        }

        public static string DrawDocksWithTruckAtPosition(int truckPosition)
		{
			string outString = string.Empty;
			outString += $"=================Time:{time}==========================================\n";
            outString += "Entrance\n";
            for (int i = 0; i < docks.Count(); i++)
			{
				if (truckPosition == i)
				{
					outString += $"|_|_>\t\t\t\t{docks[i].iterationString()}";
				}
				else
				{
                    outString += $"\t\t\t\t{docks[i].iterationString()}";
                }
				outString += "\n";
			}
            outString += "\t\t\t\t\t\t\t\tExit\n";
            outString += "==================================================================\n";
			return outString;
        }

        public static string DrawTruckMovingForward(int truckPosition, int offset)
        {
            string outString = string.Empty;
			string firstTabString = new string('\t', offset);
			string lastTabString = new string('\t', 4 - offset);
            outString += $"=================Time:{time}==========================================\n";
            outString += "Entrance\n";
            for (int i = 0; i < docks.Count(); i++)
            {
                if (truckPosition == i)
                {
                    outString += $"{firstTabString}|_|_>{lastTabString}{docks[i].iterationString()}";
                }
                else
                {
                    outString += $"\t\t\t\t{docks[i].iterationString()}";
                }
                outString += "\n";
            }
            outString += "\t\t\t\t\t\t\t\tExit\n";
            outString += "==================================================================\n";
            return outString;
        }
    }
}

