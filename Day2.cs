using System.Xml;

class Day2
{
    public static void Solution()
    { 
        string[] input = File.ReadAllLines("Day2.txt");
        int gameindex = 0;
        int gametotal = 0;
        int powerTotal = 0;
        bool isValid = true;
        int highestRed = 0;
        int highestBlue = 0;
        int highestGreen = 0;

        foreach (string game in input)
        {
            isValid = true;    
            highestRed = 0;
            highestBlue = 0;
            highestGreen = 0; 
            string[] split = game.Substring(5).Split(':');
            gameindex = int.Parse(split[0]);
            string[] pulls = split[1].Split(";");
            foreach (string pull in pulls)
            {
                string[] sets = pull.Split(",");
                foreach (string set in sets)
                {
                    string setNums = set.Replace("blue", " ").Replace("green", " ").Replace("red", " ").Trim();
                    int nums = int.Parse(setNums);
                    if ((set.Contains("red") && nums > 12) || (set.Contains("green") && nums > 13) || (set.Contains("blue") && nums > 14))
                    {
                        isValid = false;
                    }
                    if (set.Contains("red"))
                    {
                        if(nums > highestRed)
                        {
                            highestRed = nums;
                        }
                    }
                    else if (set.Contains("blue"))
                    {
                        if (nums > highestBlue)
                        {
                            highestBlue = nums;
                        }
                    }
                    else if (set.Contains("green"))
                    {
                        if(nums > highestGreen)
                        {
                            highestGreen = nums;
                        }
                    }
                }
            }
            if( isValid )
            {
                gametotal += gameindex;
            }
            powerTotal += (highestRed * highestGreen * highestBlue);
        }
        Console.WriteLine(gametotal);
        Console.WriteLine(powerTotal);

    }
}