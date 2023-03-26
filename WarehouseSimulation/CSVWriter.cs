///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Warehouse Project 3
// Description: Class that Opens and Creates the necessary files and folders for the simulation to log csv data. Also writes to the CSV.
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Text.RegularExpressions;

namespace WarehouseSimulation
{
	public class CSVWriter
	{
        public static string filePath;

        /// <summary>
        /// Prepares the log file and the log folder
        /// </summary>
        public static void prepLogFile()
        {
            Directory.CreateDirectory("../../../Logs");
            string[] files = Directory.GetFiles("../../../Logs");
            string pattern = @"\d+";

            int highestValue = 0;
            foreach (string fileName in files)
            {
                string matchValue = Regex.Match(fileName, pattern).Value;
                int currentValue = int.Parse(matchValue);
                if (highestValue < currentValue)
                    highestValue = currentValue;
            }

            filePath = $"../../../Logs/test{highestValue + 1}.csv";
        }

        /// <summary>
        /// Writes info to the log csv file
        /// </summary>
        /// <param name="content"> Info to write to the file </param>
        public static void writeToLog(string content)
        {
            File.AppendAllText(filePath, content);
        }


    }
}

