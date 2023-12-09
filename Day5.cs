using System;

public class Day5
{
    public static void Solution()
    {
        //string[] input = File.ReadAllLines("Day5.txt");
        string input = File.ReadAllText("Day5.txt");
        //string input = "seeds: 79 14 55 13\r\n\r\nseed-to-soil map:\r\n50 98 2\r\n52 50 48\r\n\r\nsoil-to-fertilizer map:\r\n0 15 37\r\n37 52 2\r\n39 0 15\r\n\r\nfertilizer-to-water map:\r\n49 53 8\r\n0 11 42\r\n42 0 7\r\n57 7 4\r\n\r\nwater-to-light map:\r\n88 18 7\r\n18 25 70\r\n\r\nlight-to-temperature map:\r\n45 77 23\r\n81 45 19\r\n68 64 13\r\n\r\ntemperature-to-humidity map:\r\n0 69 1\r\n1 0 69\r\n\r\nhumidity-to-location map:\r\n60 56 37\r\n56 93 4";
        string[] sections = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        long currentNumber = 0;
        long finalNumber = 0;
        bool isSoil = false;
        bool isFert = false;
        bool isWater = false;
        bool isLight = false;
        bool isTemp = false;
        bool isHumid = false;
        bool isLocated = false;


        string[] seeds = sections[0].Substring(7).Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] seed2Soils = sections[1].Substring(17).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] soil2Ferts = sections[2].Substring(23).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] fert2Waters = sections[3].Substring(24).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] water2Lights = sections[4].Substring(19).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] light2Temps = sections[5].Substring(25).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] temp2Humids = sections[6].Substring(28).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] humid2Locations = sections[7].Substring(25).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < seeds.Length; i += 2)
        {
            string seed = seeds[i];
            Console.WriteLine(seed);
            for (int j = 0; j < Int64.Parse(seeds[i + 1]); j++)
            {
                isSoil = false;
                isFert = false;
                isWater = false;
                isLight = false;
                isTemp = false;
                isHumid = false;
                isLocated = false;
                currentNumber = (Int64.Parse(seed)+j);
                foreach (string seed2Soil in seed2Soils)
                {
                    if (!isSoil)
                    {
                        if (currentNumber >= Int64.Parse(seed2Soil.Split(' ')[1]) && currentNumber < (Int64.Parse(seed2Soil.Split(' ')[1]) + Int64.Parse(seed2Soil.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(seed2Soil.Split(' ')[0]) + (currentNumber - Int64.Parse(seed2Soil.Split(' ')[1]));
                            isSoil = true;
                        }
                    }
                }
                foreach (string soil2Fert in soil2Ferts)
                {
                    if (!isFert)
                    {
                        if (currentNumber >= Int64.Parse(soil2Fert.Split(' ')[1]) && currentNumber < (Int64.Parse(soil2Fert.Split(' ')[1]) + Int64.Parse(soil2Fert.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(soil2Fert.Split(' ')[0]) + (currentNumber - Int64.Parse(soil2Fert.Split(' ')[1]));
                            isFert = true;
                        }
                    }
                }
                foreach (string seed2Soil in fert2Waters)
                {
                    if (!isWater)
                    {
                        if (currentNumber >= Int64.Parse(seed2Soil.Split(' ')[1]) && currentNumber < (Int64.Parse(seed2Soil.Split(' ')[1]) + Int64.Parse(seed2Soil.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(seed2Soil.Split(' ')[0]) + (currentNumber - Int64.Parse(seed2Soil.Split(' ')[1]));
                            isWater = true;
                        }
                    }
                }
                foreach (string seed2Soil in water2Lights)
                {
                    if (!isLight)
                    {
                        if (currentNumber >= Int64.Parse(seed2Soil.Split(' ')[1]) && currentNumber < (Int64.Parse(seed2Soil.Split(' ')[1]) + Int64.Parse(seed2Soil.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(seed2Soil.Split(' ')[0]) + (currentNumber - Int64.Parse(seed2Soil.Split(' ')[1]));
                            isLight = true;
                        }
                    }
                }
                foreach (string seed2Soil in light2Temps)
                {
                    if (!isTemp)
                    {
                        if (currentNumber >= Int64.Parse(seed2Soil.Split(' ')[1]) && currentNumber < (Int64.Parse(seed2Soil.Split(' ')[1]) + Int64.Parse(seed2Soil.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(seed2Soil.Split(' ')[0]) + (currentNumber - Int64.Parse(seed2Soil.Split(' ')[1]));
                            isTemp = true;
                        }
                    }
                }
                foreach (string seed2Soil in temp2Humids)
                {
                    if (!isHumid)
                    {
                        if (currentNumber >= Int64.Parse(seed2Soil.Split(' ')[1]) && currentNumber < (Int64.Parse(seed2Soil.Split(' ')[1]) + Int64.Parse(seed2Soil.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(seed2Soil.Split(' ')[0]) + (currentNumber - Int64.Parse(seed2Soil.Split(' ')[1]));
                            isHumid = true;
                        }
                    }
                }
                foreach (string seed2Soil in humid2Locations)
                {
                    if (!isLocated)
                    {
                        if (currentNumber >= Int64.Parse(seed2Soil.Split(' ')[1]) && currentNumber < (Int64.Parse(seed2Soil.Split(' ')[1]) + Int64.Parse(seed2Soil.Split(' ')[2])))
                        {
                            currentNumber = Int64.Parse(seed2Soil.Split(' ')[0]) + (currentNumber - Int64.Parse(seed2Soil.Split(' ')[1]));
                            isLocated = true;
                        }
                    }
                }
                //Console.WriteLine(currentNumber);
                if (finalNumber == 0 || currentNumber < finalNumber)
                {
                    finalNumber = currentNumber;
                }
            }
        }
        Console.WriteLine(finalNumber);
    }
}
