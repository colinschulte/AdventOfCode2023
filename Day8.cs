using System;

public class Day8
{
	public static void Solution()
	{
        string[] input = File.ReadAllLines("Day8.txt");
        int lineCount = 0;
        int turnCount = 0;
        string directions = input[0];
        string currentCode = "";
        int countCounts = 0;
        List<int> currentLines = new List<int>();
        List<int> newCurrentLines = new List<int>();
        bool allZs = false;

        foreach(string line in input)
        {
            if(lineCount >= 2)
            {
                if (line[2] == 'A')
                {
                    currentLines.Add(lineCount);
                }
            }
            lineCount++;
        }
        while (!allZs)
        {
            //allZs = true;
            countCounts = 0;
            foreach(int currentLine in currentLines)
            {

                string[] values = input[currentLine].Split(new string[] { " ", ",", "=", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                if (directions[turnCount % directions.Length] == 'L')
                {
                    currentCode = values[1];
                }
                else
                {
                    currentCode = values[2];
                }

                newCurrentLines.Add(Array.FindIndex(input, x => x.StartsWith(currentCode)));
                countCounts++;
            }
            turnCount++;
            currentLines = new List<int>(newCurrentLines);
            newCurrentLines.Clear();
            if (input[currentLines[0]][2] == 'Z' && input[currentLines[1]][2] == 'Z' && input[currentLines[2]][2] == 'Z' && input[currentLines[3]][2] == 'Z' && input[currentLines[4]][2] == 'Z' && input[currentLines[5]][2] == 'Z')
            {
                allZs = true;
            }
        }
        Console.WriteLine(turnCount.ToString());
    }
}
