using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Contracts;

namespace Implementations
{
    public class ReadInput : IInputService
    {
        public List<string> inputData;
        public List<string> complianceMapData;

        private readonly IComplianceMapService _complianceMapService;

        public ReadInput(IComplianceMapService complianceMapService)
        {
            _complianceMapService = complianceMapService;
        }

        public void ReadDataIn(string[] args)
        {
            if (args.Length > 0)
                complianceMapData = ReadFileData(args[0]);
            else
                complianceMapData = ReadUserData();

            _complianceMapService.WriteComplianceMap(complianceMapData);
        }

        public List<string> ReadFileData(string fileName)
        {
            var step = 1;
            var rows = 1;
            var columns = 0;
            List<string> finalMap = new List<string>();

            StreamReader sr = new StreamReader(fileName);
            while (rows > 0)
            {
                var finalArray = new List<char[]>();
                List<string> complianceMap = new List<string>();
                var firstLine = sr.ReadLine().Split(" ").ToArray();
                rows = Convert.ToInt32(firstLine[0]);
                columns = Convert.ToInt32(firstLine[1]);

                for (int i = 0; i < rows; i++)
                {

                    finalArray.Add(sr.ReadLine().Select(c => c).ToArray());
                }
                complianceMap = _complianceMapService.CreateComplianceMap(finalArray, rows, columns, step); //AdjacentElements(finalArray, rows, columns, step);
                finalMap.AddRange(complianceMap);
                finalMap.Add("");
                step++;
            }
            step--;
            finalMap.Remove("Set #" + step.ToString());

            return finalMap;
        }

        public List<string> ReadUserData()
        {
            int rows = 0;
            int columns = 0;
            int step = 1;
            List<string> finalMap = new List<string>();

            Console.WriteLine("Enter Mapping Data");

            var userInput = Console.ReadLine();

            while (userInput != "0 0")
            {
                var finalArray = new List<char[]>();
                List<string> complianceMap = new List<string>();
                var firstLine = userInput.Split(" ").ToArray();
                rows = Convert.ToInt32(firstLine[0]);
                columns = Convert.ToInt32(firstLine[1]);
                for (int i = 0; i < rows; i++)
                {

                    finalArray.Add(Console.ReadLine().Select(c => c).ToArray());
                }
                complianceMap = _complianceMapService.CreateComplianceMap(finalArray, rows, columns, step);
                finalMap.AddRange(complianceMap);
                finalMap.Add("");
                step++;
                Console.WriteLine("Enter next set or 0 0 to process entered data");
                userInput = Console.ReadLine();
            }
            return finalMap;
        }
    }
}
