///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Warehouse Project 3
// Description: Class that outputs the visuals for the simulation.
//
///////////////////////////////////////////////////////////////////////////////

using System;
namespace WarehouseSimulation
{
	public class OutputDraw
	{
        public static List<Dock> docks { get; set; }
        public static int time = 0;


        /// <summary>
        /// Outputs the visual of a truck entering a dock.
        /// </summary>
        /// <param name="dockNum"> Dock the truck is entering </param>
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

        /// <summary>
        /// Outputs the end of the simulation.
        /// </summary>
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

        /// <summary>
        /// Outputs a visual of a truck exiting a line
        /// </summary>
        /// <param name="dockNum"> Dock the truck is exiting from </param>
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

        /// <summary>
        /// Draws a truck at the exit of a specific dock.
        /// </summary>
        /// <param name="truckPosition"> Dock the truck is being drawn at </param>
        /// <returns> a string of a truck at the exit of a specific dock </returns>
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

        /// <summary>
        /// Draws a truck a speicific dock.
        /// </summary>
        /// <param name="truckPosition"> Dock the truck is being drawn at </param>
        /// <returns> a string of a truck at a specific dock </returns>
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

        /// <summary>
        /// Draws a truck moving forward at a specific dock
        /// </summary>
        /// <param name="truckPosition"> Dock the truck is being drawn at </param>
        /// <param name="offset"> How far the truck has moved forward </param>
        /// <returns> a string of a truck a set distance away from a specific dock </returns>
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

