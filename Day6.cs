using System;

public class Day6
{
    public static void Solution()
    {
        string[] input = File.ReadAllLines("Day6.txt");
        string[] times = input[0].Substring(11).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        string newTime = String.Join("", times);
        string[] distances = input[1].Substring(11).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        string newDistance = String.Join("", distances);
        int columnNum = 0;
        int runDistance = 0;
        long newRunDistance = 0;
        int validRuns = 0;
        int totalValidRuns = 1;


        foreach (string time in times)
        {
            int intTime = int.Parse(time);
            for (int i = 0; i <= intTime; i++)
            {
                runDistance = i * (intTime - i);
                if (runDistance > int.Parse(distances[columnNum]))
                {
                    validRuns++;
                }
            }
            totalValidRuns *= validRuns;
            validRuns = 0;
            columnNum++;
        }
        Console.WriteLine(totalValidRuns);

        int newIntTime = int.Parse(newTime);
        for (long i = 0; i <= newIntTime; i++)
        {
            newRunDistance = i * (newIntTime - i);
            if (newRunDistance > Int64.Parse(newDistance))
            {
                validRuns++;
            }
        }
        Console.WriteLine(validRuns);
    }
}
