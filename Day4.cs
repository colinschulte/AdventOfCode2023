using System;

public class Day4
{
	public static void Solution()
	{
        string[] input = File.ReadAllLines("Day4.txt");
        List<int> wins = new List<int>();
        bool isWinner = false;
        int cardValue = 0;
        int totalValue = 0;
        int numOfCards = 1;
        int totalnumCards = 0;
        int cardWins = 0;
        int totalCardWins = 0;
        foreach (string line in input)
        {
            isWinner = false;
            cardValue = 0;
            numOfCards = 1;
            cardWins = 0;
            foreach (int win in wins)
            {
                if(win > 0)
                {
                    numOfCards++;
                    
                }
            }
            for(int i = 0; i < wins.Count; i++)
            {
                wins[i] = wins[i] - 1;
            }

            string[] splitline = line.Split(':');
            string[] splitNums = splitline[1].Split('|');
            string[] winningNums = splitNums[0].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] playerNums = splitNums[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach(string playerNum in playerNums)
            {
                if(Array.IndexOf(winningNums, playerNum) != -1)
                {
                    if (!isWinner)
                    {
                        cardValue = 1;
                        isWinner = true;
                    }
                    else
                    {
                        cardValue *= 2;
                    }
                    cardWins++;
                }
            }
            totalValue += cardValue;
            totalCardWins = cardWins * numOfCards;
            totalnumCards += numOfCards;
            for(int i = 0; i < numOfCards; i++)
            {
                wins.Add(cardWins);
            }
        }
        Console.WriteLine(totalnumCards);
        Console.WriteLine(totalValue.ToString());
    }
}
