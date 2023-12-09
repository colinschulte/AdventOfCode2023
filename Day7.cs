using System;
using System.Collections.Generic;
using System.Linq;

public class Day7
{
	public static void Solution()
	{
        string[] input = File.ReadAllLines("Day7.txt");
        List<List<string>> list = new List<List<string>>();
        list.Add(new List<string>());
        list.Add(new List<string>());
        list.Add(new List<string>());
        list.Add(new List<string>());
        list.Add(new List<string>());
        list.Add(new List<string>());
        list.Add(new List<string>());
        //List<string> fiveAKind = new List<string>();
        //List<string> fourAKind = new List<string>();
        //List<string> fullHouse = new List<string>();
        //List<string> threeAKind = new List<string>();
        //List<string> twoPair = new List<string>();
        //List<string> onePair = new List<string>();
        //List<string> highCard = new List<string>();
        string order = "J23456789TQKA";
        int topHandCount = 0;
        int secondHandCount = 0;
        int jokerCount = 0;
        int betCount = 1;
        long cardValue = 0;
        long handValue = 1;
        long totalWinnings = 0;
        bool isJoker = true;
        Dictionary<long,int> handValues = new Dictionary<long,int>();


        foreach (string line in input)
        {
            topHandCount = 0;
            secondHandCount = 0;
            isJoker = true;
            string hand = line.Split(' ')[0];
            foreach(char o in order)
            {
                int handCount = hand.Count(x => x == o);
                if (isJoker)
                {
                    jokerCount = handCount;
                    isJoker = false;
                }
                else if(handCount > topHandCount)
                {
                    secondHandCount = topHandCount;
                    topHandCount = handCount;
                }
                else if(handCount > secondHandCount)
                {
                    secondHandCount = handCount;
                }
            }
            switch (topHandCount + jokerCount)
            {
                case 1:
                    list[0].Add(line);
                    break;
                case 2:
                    if(secondHandCount == 2)
                    {
                        list[2].Add(line);
                    }
                    else
                    {
                        list[1].Add(line);
                    }
                    break;
                case 3:
                    if(secondHandCount == 2)
                    {
                        list[4].Add(line);
                    }
                    else
                    {
                        list[3].Add(line);
                    }
                    break;
                case 4:
                    list[5].Add(line);
                    break;
                case 5:
                    list[6].Add(line);
                    break;
            }
        }
        foreach (List<string> subList in list)
        {
            foreach (string line in subList)
            {
                //Console.WriteLine(line);
                string hand = line.Split(' ')[0];
                foreach (char card in hand)
                {
                    long value = 1;
                    foreach (char o in order)
                    {
                        if (o == card)
                        {
                            cardValue = value;
                        }
                        value++;
                    }
                    handValue = (handValue * 100) + cardValue;
                }
                handValues.Add(handValue, int.Parse(line.Split(' ')[1]));
                handValue = 1;
            }
            foreach(KeyValuePair<long,int> pair in handValues.OrderBy(x => x.Key))
            {
                totalWinnings += (pair.Value * betCount);
                betCount++;
            }
            handValues.Clear();
        }
        Console.WriteLine(totalWinnings);
    }
}
