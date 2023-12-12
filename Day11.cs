using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Day11
{
    public static void Solution()
    {
        string[] input = File.ReadAllLines("Day11.txt");
        List<string> listInput = input.ToList();
        List<(int, int)> galaxyCoords = new List<(int, int)>();
        List<int> colList = new List<int>();
        List<int> blankRows = new List<int>();
        List<int> blankCols = new List<int>();
        int rowNum = 0;
        int colNum = 0;
        double shortestDistance = 0;
        double totalDistance = 0;
        bool rowEmpty = true;
        int extraRowCount = 0;
        int extraColCount = 0;

        foreach (string line in input)
        {
            rowEmpty = true;
            foreach (char c in line)
            {
                if (c == '#')
                {
                    colList.Add(colNum);
                    rowEmpty = false;
                }
                colNum++;
            }
            if (rowEmpty)
            {
                blankRows.Add(rowNum + extraRowCount);
                listInput.Insert(rowNum + extraRowCount, line);
                extraRowCount++;
            }
            rowNum++;
            colNum = 0;
        }
        for(int i = 0; i < input[0].Length; i++)
        {
            if(!colList.Contains(i)) 
            {
                blankCols.Add(i + extraColCount);
                for(int j = 0; j < listInput.Count; j++) 
                {
                    List<char> brokenLine = listInput[j].ToCharArray().ToList();
                    brokenLine.Insert(i + extraColCount, '.');
                    listInput[j] = new string(brokenLine.ToArray());
                }
                extraColCount++;
                i++;
            }
        }
        rowNum = 0;
        colNum = 0;
        foreach (string line in listInput)
        {
            foreach(char c in line)
            {
                if(c == '#')
                {
                    galaxyCoords.Add((rowNum, colNum));
                }
                colNum++;
            }
            rowNum++;
            colNum = 0;
            Console.WriteLine(line);
        }
        int totalRuns = 0;
        int startInt = 0;
        foreach((int, int) coords in galaxyCoords)
        {
            int countInt = startInt;
            while (countInt < galaxyCoords.Count)
            {
                shortestDistance = Math.Abs(coords.Item1 - galaxyCoords[countInt].Item1) + Math.Abs(coords.Item2 - galaxyCoords[countInt].Item2);
                totalDistance += shortestDistance;
                countInt++;
                totalRuns++;
            }
            startInt++;
        }
        Console.WriteLine(totalDistance);
    }
}
