using System;
using System.Collections.Generic;
using System.Text;
using Contracts;

namespace Implementations
{
    public class ComplianceMapping : IComplianceMapService
    {

        public List<string> CreateComplianceMap(List<char[]> mapArray, int rows, int columns, int step)
        {
            List<string> mapValues = new List<string>();
            mapValues.Add("Set #" + step.ToString());
            string rowString = string.Empty;

            char test;

            for (int row = 0; row < rows; row++)
            {
                rowString = string.Empty;
                for (int col = 0; col < columns; col++)
                {
                    int complianceValue = 0;
                    if (mapArray[row][col] == 42)
                    {
                        rowString += "*";
                    }
                    else
                    {
                        List<int> columnsToInspect = new List<int>();
                        List<int> rowsToInspect = new List<int>();

                        //build list of columns to look at
                        if (col - 1 >= 0)
                            columnsToInspect.Add(-1);
                        columnsToInspect.Add(0);
                        if (col + 1 < columns)
                            columnsToInspect.Add(1);
                        
                        //build list of rows to look at
                        if (row - 1 >= 0)
                            rowsToInspect.Add(-1);
                        rowsToInspect.Add(0);
                        if (row + 1 < rows)
                            rowsToInspect.Add(1);

                        foreach (var rowItem in rowsToInspect)
                        {
                            foreach (var colItem in columnsToInspect)
                            {
                                int rowInt = row + rowItem;
                                int colInt = col + colItem;
                                test = mapArray[row + rowItem][col + colItem];
                                if (test == 42)
                                    complianceValue++;
                            }
                        }
                        rowString += complianceValue.ToString();
                    }
                }
                mapValues.Add(rowString);
            }
            return mapValues;
        }

        public void WriteComplianceMap(List<string> complianceMapData)
        {
            foreach (var line in complianceMapData)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine("End of entered data. Hit return to exit.");
            Console.ReadLine();
        }
    }
}
