using System;
using System.Runtime.InteropServices;

public class Day10
{
    public static void Solution()
    {
        string[] input = File.ReadAllLines("Day10.txt");
        int rowNum = 0;
        int colNum = 0;
        bool SFound = false;
        bool nextUp = true;
        bool nextDown = false;
        bool nextLeft = false;
        bool nextRight = false;
        bool hasRun = false;
        bool firstRun = true;

        (int, int) sLocation = (0,0);
        List<(int,int)> tupList = new List<(int,int)> ();

        while (!SFound)
        {
            foreach (string row in input)
            {
                foreach(char col in row) 
                {
                    if(col == 'S')
                    {
                            SFound = true;
                    }
                    if (!SFound)
                    {
                        colNum++;
                    }
                }
                if(!SFound)
                {
                    rowNum++;
                    colNum = 0;
                }
            }
        }
        sLocation = (rowNum, colNum);
        Console.WriteLine(sLocation);
        Console.WriteLine(input[rowNum][colNum]);
        SFound = false;
        int loopCount = 0;
        while(!SFound)
        {
            if (nextUp)
            {
                nextUp = false;
                rowNum--;
                if(input[rowNum][colNum] == '|')
                {
                    nextUp = true;
                }
                else if (input[rowNum][colNum] == '7')
                {
                    nextLeft = true;
                }
                else if (input[rowNum][colNum] == 'F')
                {
                    nextRight = true;
                }
                else if (input[rowNum][colNum] == 'S')
                {
                    SFound = true;
                }
            }
            else if (nextDown)
            {
                nextDown = false;
                rowNum++;
                if (input[rowNum][colNum] == '|')
                {
                    nextDown = true;
                }
                else if (input[rowNum][colNum] == 'J')
                {
                    nextLeft = true;
                }
                else if (input[rowNum][colNum] == 'L')
                {
                    nextRight = true;
                }
                else if (input[rowNum][colNum] == 'S')
                {
                    SFound = true;
                }
            }
            else if (nextLeft)
            {
                nextLeft = false;
                colNum--;
                if (input[rowNum][colNum] == 'L')
                {
                    nextUp = true;
                }
                else if (input[rowNum][colNum] == '-')
                {
                    nextLeft = true;
                }
                else if (input[rowNum][colNum] == 'F')
                {
                    nextDown = true;
                }
                else if (input[rowNum][colNum] == 'S')
                {
                    SFound = true;
                }
            }
            else if (nextRight)
            {
                nextRight = false;
                colNum++;
                if (input[rowNum][colNum] == 'J')
                {
                    nextUp = true;
                }
                else if (input[rowNum][colNum] == '7')
                {
                    nextDown = true;
                }
                else if (input[rowNum][colNum] == '-')
                {
                    nextRight = true;
                }
                else if (input[rowNum][colNum] == 'S')
                {
                    SFound = true;
                }
            }
            
            hasRun = false;
            firstRun = false;
            loopCount++;
            Console.WriteLine(loopCount);
            (int, int) currentLocation = (rowNum, colNum);
            if (tupList.Contains(currentLocation))
            {
                Console.WriteLine("MessUp");
            }
            else
            {
                tupList.Add(currentLocation);
            }
        }
        Console.WriteLine(loopCount / 2);

        string[] newMap = new string[280];
        for(int i = 0; i < (input.Length * 2); i++)
        {
            newMap[i] = "........................................................................................................................................................................................................................................................................................";
        }
        foreach((int, int) tuple in tupList)
        {
            string newLine = newMap[tuple.Item1 * 2];
            char[] brokenLine = newLine.ToCharArray();
            brokenLine[tuple.Item2 * 2] = input[tuple.Item1][tuple.Item2];
            newLine = new string(brokenLine);
            newMap[tuple.Item1 * 2] = newLine;
        }
        int lineCount = 0;
        int charCount = 0;
        foreach(string line in newMap)
        {
            char[] brokenLine = line.ToCharArray();
            if (lineCount % 2 == 1)
            {
                foreach (char c in brokenLine)
                {
                    if(lineCount > 0)
                    {
                        if (newMap[lineCount - 1][charCount] == '|' || newMap[lineCount - 1][charCount] == 'F' || newMap[lineCount - 1][charCount] == '7')
                        {
                            brokenLine[charCount] = '|';
                        }
                    }
                    charCount++;
                }
            }
            else
            {
                foreach (char c in brokenLine)
                {
                    if (charCount > 0)
                    {
                        if (newMap[lineCount][charCount - 1] == '-' || newMap[lineCount][charCount - 1] == 'L' || newMap[lineCount][charCount - 1] == 'F')
                        {
                            brokenLine[charCount] = '-';
                        }
                    }
                    charCount++;
                }
            }
            newMap[lineCount] = new string(brokenLine);
            Console.WriteLine(newMap[lineCount]);
            lineCount++;
            charCount = 0;
        }
        List<(int, int)> outerCoords = new List<(int, int)>();
        List<(int, int)> coordsToCheck = new List<(int, int)>();
        (int, int) currentCoords = (0, 0);
        int startRow = 0;
        int startCol = 0;
        coordsToCheck.Add((startRow, startCol));
        outerCoords.Add((startRow, startCol));
        while (coordsToCheck.Count > 0)
        {
            currentCoords = coordsToCheck[0];
            //Console.WriteLine(currentCoords);
            if(currentCoords.Item1 > 0)
            {
                if (newMap[currentCoords.Item1 - 1][currentCoords.Item2] == '.' && !outerCoords.Contains((currentCoords.Item1 - 1, currentCoords.Item2)))
                {
                    outerCoords.Add((currentCoords.Item1 - 1, currentCoords.Item2));
                    coordsToCheck.Add((currentCoords.Item1 - 1, currentCoords.Item2));
                }
                if (currentCoords.Item2 > 0)
                {
                    if (newMap[currentCoords.Item1 - 1][currentCoords.Item2 - 1] == '.' && !outerCoords.Contains((currentCoords.Item1 - 1, currentCoords.Item2 - 1)))
                    {
                        outerCoords.Add((currentCoords.Item1 - 1, currentCoords.Item2 - 1));
                        coordsToCheck.Add((currentCoords.Item1 - 1, currentCoords.Item2 - 1));
                    }

                }

            }
            if(currentCoords.Item1 < newMap.Length - 1)
            {
                if (newMap[currentCoords.Item1 + 1][currentCoords.Item2] == '.' && !outerCoords.Contains((currentCoords.Item1 + 1, currentCoords.Item2)))
                {
                    outerCoords.Add((currentCoords.Item1 + 1, currentCoords.Item2)); 
                    coordsToCheck.Add((currentCoords.Item1 + 1, currentCoords.Item2));
                }
                if (currentCoords.Item2 < newMap.Length - 1)
                {
                    if (newMap[currentCoords.Item1 + 1][currentCoords.Item2 + 1] == '.' && !outerCoords.Contains((currentCoords.Item1 + 1, currentCoords.Item2 + 1)))
                    {
                        outerCoords.Add((currentCoords.Item1 + 1, currentCoords.Item2 + 1));
                        coordsToCheck.Add((currentCoords.Item1 + 1, currentCoords.Item2 + 1));
                    }
                }
            }
            if (currentCoords.Item2 > 0)
            {
                if (newMap[currentCoords.Item1][currentCoords.Item2 - 1] == '.' && !outerCoords.Contains((currentCoords.Item1, currentCoords.Item2 - 1)))
                {
                    outerCoords.Add((currentCoords.Item1, currentCoords.Item2 - 1));
                    coordsToCheck.Add((currentCoords.Item1, currentCoords.Item2 - 1));
                }
                if (currentCoords.Item1 < newMap.Length - 1)
                {
                    if (newMap[currentCoords.Item1 + 1][currentCoords.Item2 - 1] == '.' && !outerCoords.Contains((currentCoords.Item1 + 1, currentCoords.Item2 - 1)))
                    {
                        outerCoords.Add((currentCoords.Item1 + 1, currentCoords.Item2 - 1));
                        coordsToCheck.Add((currentCoords.Item1 + 1, currentCoords.Item2 - 1));
                    }

                }
            }
            if (currentCoords.Item2 < newMap.Length - 1)
            {
                if (newMap[currentCoords.Item1][currentCoords.Item2 + 1] == '.' && !outerCoords.Contains((currentCoords.Item1, currentCoords.Item2 + 1)))
                {
                    outerCoords.Add((currentCoords.Item1, currentCoords.Item2 + 1));
                    coordsToCheck.Add((currentCoords.Item1, currentCoords.Item2 + 1));
                }
                if (currentCoords.Item1 > 0)
                {
                    if (newMap[currentCoords.Item1 - 1][currentCoords.Item2 + 1] == '.' && !outerCoords.Contains((currentCoords.Item1 - 1, currentCoords.Item2 + 1)))
                    {
                        outerCoords.Add((currentCoords.Item1 - 1, currentCoords.Item2 + 1));
                        coordsToCheck.Add((currentCoords.Item1 - 1, currentCoords.Item2 + 1));
                    }
                }
            }
            //Console.WriteLine(outerCoords.Count);
            coordsToCheck.Remove(currentCoords);
        }
        foreach (var coords in outerCoords)
        {
            //Console.WriteLine(coords);
            char[] brokenLine = newMap[coords.Item1].ToCharArray();
            brokenLine[coords.Item2] = '*';
            newMap[coords.Item1] = new string(brokenLine);
        }
        lineCount = 0;
        charCount = 0;
        int dotCount = 0;
        foreach (string line in newMap)
        {
            if (lineCount % 2 == 0)
            {
                foreach(char c in line)
                {
                    if (charCount % 2 == 0 && c == '.') 
                    {
                        dotCount++;
                    }
                    charCount++;
                }
            }
            lineCount++;
            charCount = 0;
        }
        //Console.WriteLine(outerCoords.Count);
        //int finalAnswer = (140 * 140) - outerCoords.Count - loopCount;
        //Console.WriteLine(finalAnswer);
        Console.WriteLine(dotCount);
    }
}