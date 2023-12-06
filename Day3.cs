using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Day3
{
    public static void Solution()
    {
        string[] input = File.ReadAllLines("Day3.txt");
        List<int> currentGearNums = new List<int>();
        string numbers = "1234567890";
        string currentNum = "";
        string currentGearNum = "";
        int currentRatio = 1;
        int totalRatio = 0;
        int totalPartNums = 0;
        int rowNum = 0;
        int colNum = 0;
        int adjNums = 0;
        int outcheck = 1;
        bool isPart = false;
        bool isContinuing = false;
        bool isGearContinuing = false;
        Dictionary<(int, int), int> gears = new Dictionary<(int, int), int>();

        for (int i = 0; i < input.Length; i++)
        {
            input[i] = "." + input[i] + '.';
        }
        foreach (string line in input)
        {
            foreach (char c in line)
            {
                if (numbers.Contains(c))
                {
                    currentNum += c;
                    isContinuing = false;
                    if (rowNum > 1)
                    {
                        if (colNum > 1)
                        {
                            char upLeft = input[rowNum - 1][colNum - 1];
                            if (upLeft != '.' && !numbers.Contains(upLeft))
                            {
                                isPart = true;
                            }
                        }
                        char up = input[rowNum - 1][colNum];
                        if (up != '.' && !numbers.Contains(up))
                        {
                            isPart = true;
                        }
                        if (colNum < line.Length - 1)
                        {
                            char upRight = input[rowNum - 1][colNum + 1];
                            if (upRight != '.' && !numbers.Contains(upRight))
                            {
                                isPart = true;
                            }
                        }
                    }
                    if (colNum > 1 && currentNum.Length <= 1)
                    {
                        char left = input[rowNum][colNum - 1];
                        if (left != '.' && !numbers.Contains(left))
                        {
                            isPart = true;
                        }
                    }
                    if (colNum < line.Length - 1)
                    {
                        char right = input[rowNum][colNum + 1];
                        if (numbers.Contains(right))
                        {
                            isContinuing = true;
                        }
                        else if (right != '.')
                        {
                            isPart = true;
                        }
                    }
                    if (rowNum < input.Length - 1)
                    {
                        if (colNum > 1)
                        {
                            char downLeft = input[rowNum + 1][colNum - 1];
                            if (downLeft != '.' && !numbers.Contains(downLeft))
                            {
                                isPart = true;
                            }
                        }
                        char down = input[rowNum + 1][colNum];
                        if (down != '.' && !numbers.Contains(down))
                        {
                            isPart = true;
                        }
                        if (colNum < line.Length - 1)
                        {
                            char downRight = input[rowNum + 1][colNum + 1];
                            if (downRight != '.' && !numbers.Contains(downRight))
                            {
                                isPart = true;
                            }
                        }
                    }
                    if (!isContinuing)
                    {
                        if (isPart)
                        {
                            totalPartNums += Int32.Parse(currentNum);
                            isPart = false;
                        }
                        currentNum = "";
                    }
                }
                if (c == '*')
                {
                    if (rowNum > 0)
                    {
                        char up = input[rowNum - 1][colNum];
                        if (numbers.Contains(up))
                        {
                            currentGearNum += up;
                        }
                        if (colNum > 0)
                        {
                            isGearContinuing = true;
                            outcheck = 1;
                            while (isGearContinuing)
                            {
                               
                                    char upLeft = input[rowNum - 1][colNum - outcheck];
                                    if (numbers.Contains(upLeft))
                                    {
                                        currentGearNum = upLeft + currentGearNum;
                                    
                                        outcheck++;
                                }
                                else
                                {
                                    isGearContinuing = false;
                                }
                            }
                        }
                        if (currentGearNum.Length > 0 && !numbers.Contains(up))
                        {
                            currentGearNums.Add(Int32.Parse(currentGearNum));
                            currentGearNum = "";
                        }
                        if (colNum < line.Length)
                        {
                            isGearContinuing = true;
                            outcheck = 1;
                            while (isGearContinuing)
                            {
                                
                                    char upRight = input[rowNum - 1][colNum + outcheck];
                                    if (numbers.Contains(upRight))
                                    {
                                        currentGearNum += upRight;
                                    
                                        outcheck++;
                                }
                                else
                                {
                                    isGearContinuing = false;
                                }
                            }
                        }
                    }
                    if (currentGearNum.Length > 0)
                    {
                        currentGearNums.Add(Int32.Parse(currentGearNum));
                        currentGearNum = "";
                    }
                    if (colNum > 0)
                    {
                        isGearContinuing = true;
                        outcheck = 1;
                        while (isGearContinuing)
                        {
                              char left = input[rowNum][colNum - outcheck];
                                if (numbers.Contains(left))
                                {
                                    currentGearNum = left + currentGearNum;
                                
                                    outcheck++;
                            }
                            else
                            {
                                isGearContinuing = false;
                            }
                        }
                    }
                    if (currentGearNum.Length > 0)
                    {
                        currentGearNums.Add(Int32.Parse(currentGearNum));
                        currentGearNum = "";
                    }
                    if (colNum < line.Length)
                    {
                        isGearContinuing = true;
                        outcheck = 1;
                        while (isGearContinuing)
                        {
                            char right = input[rowNum][colNum + outcheck];
                            if (numbers.Contains(right))
                            {
                                currentGearNum += right;
                                outcheck++;
                            }
                            else
                            {
                                isGearContinuing = false;
                            }
                        }
                    }
                    if (currentGearNum.Length > 0)
                    {
                        currentGearNums.Add(Int32.Parse(currentGearNum));
                        currentGearNum = "";
                    }
                    if (rowNum < input.Length)
                    {
                        char down = input[rowNum + 1][colNum];
                        if (numbers.Contains(down))
                        {
                            currentGearNum += down;
                        }
                        if (colNum > 0)
                        {
                            isGearContinuing = true;
                            outcheck = 1;
                            while (isGearContinuing)
                            {
                               char downLeft = input[rowNum + 1][colNum - outcheck];
                                if (numbers.Contains(downLeft))
                                {
                                    currentGearNum = downLeft + currentGearNum;
                                    outcheck++;
                                }
                                else
                                {
                                    isGearContinuing = false;
                                    outcheck = 1;
                                }
                            }
                        }
                        if (currentGearNum.Length > 0 && !numbers.Contains(down))
                        {
                            currentGearNums.Add(Int32.Parse(currentGearNum));
                            currentGearNum = "";
                        }
                        if (colNum < line.Length)
                        {
                            isGearContinuing = true;
                            outcheck = 1;
                            while (isGearContinuing)
                            { 
                                char downRight = input[rowNum + 1][colNum + outcheck];
                                if (numbers.Contains(downRight))
                                {
                                    currentGearNum += downRight;
                                    
                                    outcheck++;
                                }
                                else
                                {
                                    isGearContinuing = false;
                                }
                            }
                        }
                        if (currentGearNum.Length > 0)
                        {
                            currentGearNums.Add(Int32.Parse(currentGearNum));
                            currentGearNum = "";
                        }
                        if (currentGearNums.Count == 2)
                        {
                            foreach (int gearNum in currentGearNums)
                            {
                                currentRatio *= gearNum;
                            }
                            gears.Add((rowNum, colNum), currentRatio);
                            currentRatio = 1;
                        }
                        currentGearNums.Clear();
                    }
                }
                colNum++;
            }
            rowNum++;
            colNum = 0;
        }
        foreach (KeyValuePair<(int, int), int> gear in gears)
        {
            totalRatio += gear.Value;
        }
        Console.WriteLine(totalRatio);
        Console.WriteLine(totalPartNums.ToString());
    }
}
