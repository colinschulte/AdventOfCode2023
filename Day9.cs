using System;
using System.Runtime.InteropServices;

public class Day9
{
    public static void Solution()
    {
        string[] input = File.ReadAllLines("Day9.txt");
        int totalNumber = 0;

        foreach (string line in input)
        {
            string[] stringNums = line.Split(' ');
            int[] numbers = new int[stringNums.Length];
            List<int[]> layerNumbers = new List<int[]>();
            bool allZeros = false;
            int layerCount = 0;
            int nextNumber = 0;
            for(int i = 0; i < stringNums.Length; i++)
            {
                numbers[i] = int.Parse(stringNums[i]);
            }
            layerNumbers.Add(numbers);
            while (!allZeros)
            {
                allZeros = true;
                int[] newNumbers = new int[numbers.Length - (layerCount + 1)];
                for(int i = 0; i < newNumbers.Length; i++)
                {
                    //newNumbers[i] = numbers[i] - numbers[i+1];
                    newNumbers[i] = layerNumbers[layerCount][i+1] - layerNumbers[layerCount][i];
                    if (newNumbers[i] != 0)
                    {
                        allZeros = false;
                    }
                }
                layerNumbers.Add(newNumbers);
                layerCount++;
            }
            while(layerCount > 0)
            {
                //Part 1
                //nextNumber += layerNumbers[layerCount - 1].Last();
                //Part 2
                nextNumber = layerNumbers[layerCount - 1][0] - nextNumber;
                layerCount--;
            }
            totalNumber += nextNumber;
        }
        Console.WriteLine(totalNumber);
    }
}
