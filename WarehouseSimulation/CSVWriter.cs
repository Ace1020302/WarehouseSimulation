using System;
using System.Text.RegularExpressions;

namespace WarehouseSimulation
{
	public class CSVWriter
	{
        public static string filePath;

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

        public static void writeToLog(string content)
        {
            File.AppendAllText(filePath, content);
        }


    }
}

