using System.Xml;
class Day1
{
    public static void Solution()
    {
        string[] input = File.ReadAllLines("Day1.txt");
        string numbers = "1234567890";
        int runningTotal = 0;

        foreach (string line in input)
        {
            string digitline = "";
            //Console.WriteLine(line);
            bool isFirstDigit = true;
            char firstdigit = '0';
            char lastdigit = '0';
            digitline = line.Replace("two", "tw2o").Replace("eight", "ei8ght").Replace("one", "o1ne").Replace("three", "thr3ee").Replace("four", "fo4ur").Replace("five", "fi5ve").Replace("six", "si6x").Replace("seven", "sev7en").Replace("nine", "ni9ne");
            //Console.WriteLine(digitline);
            foreach (char c in digitline)
            {
                if (numbers.Contains(c))
                {
                    if (isFirstDigit)
                    {
                        firstdigit = c;
                        isFirstDigit = false;
                    }
                    lastdigit = c;
                }

            }
            string digits = firstdigit.ToString() + lastdigit;
            //outputs[lineCounter] = digits;
            runningTotal += Int32.Parse(digits);
        }
        Console.WriteLine(runningTotal.ToString());
    }
}